using Core.Helpers;
using Core.Serializers;
using Grpc.Core;
using interfaces.Protos;
using Interfaces.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dog_GrpcService.Services
{
    public class DogGRPC_Service : DogGrpc.DogGrpcBase
    {
        private readonly ILogger<DogGRPC_Service> _logger;

        private readonly DogSerializer _serializer;

        private IList<IDog> _dogs;

        public DogGRPC_Service(ILogger<DogGRPC_Service> logger, DogSerializer serializer)
        {
            _logger = logger;
            _serializer = serializer;
            _dogs = _serializer.Deserialize();
        }

        public override async Task GetDogs(NullRequest request, IServerStreamWriter<DogModel> responseStream, ServerCallContext context)
        {
            foreach (var response in _dogs)
            {
                var model = new DogModel()
                {
                    Id= response.Id,
                    Name = response.Name,
                    UserId = response.UserId
                };

                await responseStream.WriteAsync(model);
            }
        }

        public override async Task GetUserDogs(GetUserDogRequest request, IServerStreamWriter<DogModel> responseStream, ServerCallContext context)
        {
            if(!_dogs.Any(d => d.UserId == request.UserId))
            {
                throw new RpcException(Status.DefaultCancelled, "User do not have dogs");
            }

            foreach (var response in _dogs.Where(d => d.UserId == request.UserId))
            {
                var model = new DogModel()
                {
                    Id = response.Id,
                    Name = response.Name,
                    UserId = response.UserId
                };

                await responseStream.WriteAsync(model);
            }
        }

        public override async Task<DogModel> GetDog(DogIdRequest request, ServerCallContext context)
        {
            if (!_dogs.Any(d => d.Id == request.Id))
            {
                throw new RpcException(Status.DefaultCancelled, "Dog do not found");
            }
            return _dogs.First(d => d.Id == request.Id).ToGrpc();
        }

        public override async Task<DogModel> AddDog(AddDogRequest request, ServerCallContext context)
        {
            int id = _dogs.Any() ? _dogs.Max(d => d.Id) + 1 : 0;
            var dog = new DogModel()
            {
                Id = id,
                Name = request.Name,
                UserId = request.UserId
            };

            _dogs.Add(dog.FromGrpc());

            _serializer.Serialize(_dogs);

            return dog;
        }

        public override async Task<DogModel> RemoveDog(DogIdRequest request, ServerCallContext context)
        {
            if (!_dogs.Any(d => d.Id == request.Id))
            {
                throw new RpcException(Status.DefaultCancelled, "Dog cannot be removed. Not found");
            }

            var dog = _dogs.First(d => d.Id == request.Id);

            _dogs.Remove(dog);

            _serializer.Serialize(_dogs);

            return dog.ToGrpc();
        }

        public override async Task<DogModel> AdoptDog(AdoptDogRequest request, ServerCallContext context)
        {
            if (!_dogs.Any(d => d.Id == request.Id))
            {
                throw new RpcException(Status.DefaultCancelled, "Dog cannot be adopted. Not found");
            }

            var dog = _dogs.First(d => d.Id == request.Id);

            //Разница?
            var index = _dogs.IndexOf(dog);
            _dogs[index].UserId = request.UserId;
            //или так можно??
            dog.UserId = request.UserId;

            _serializer.Serialize(_dogs);

            return dog.ToGrpc();
        }
    }
}
