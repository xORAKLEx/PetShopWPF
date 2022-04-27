using Grpc.Core;
using interfaces.Protos;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace Dog_GrpcService.Services
{
    public class DogGRPC_Service : DogGrpc.DogGrpcBase
    {
        private readonly ILogger<DogGRPC_Service> _logger;

        public DogGRPC_Service(ILogger<DogGRPC_Service> logger)
        {
            _logger = logger;
        }

        public override Task GetDogs(NullRequest request, IServerStreamWriter<DogModel> responseStream, ServerCallContext context)
        {
            return base.GetDogs(request, responseStream, context);
        }

        public override Task GetUserDogs(GetUserDogRequest request, IServerStreamWriter<DogModel> responseStream, ServerCallContext context)
        {
            return base.GetUserDogs(request, responseStream, context);
        }

        public override Task<DogModel> GetDog(DogIdRequest request, ServerCallContext context)
        {
            return base.GetDog(request, context);
        }

        public override Task<DogModel> AddDog(AddDogRequest request, ServerCallContext context)
        {
            return base.AddDog(request, context);
        }

        public override Task<DogModel> RemoveDog(DogIdRequest request, ServerCallContext context)
        {
            return base.RemoveDog(request, context);
        }

        public override Task<DogModel> AdoptDog(AdoptDogRequest request, ServerCallContext context)
        {
            return base.AdoptDog(request, context);
        }
    }
}
