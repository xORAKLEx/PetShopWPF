using Core.Models;
using interfaces.Protos;
using Interfaces.Models;

namespace Core.Helpers
{
    public static class DogServiceHelper
    {
        public static DogModel ToGrpc(this IDog dog)
        {
            return new DogModel()
            {
                Id = dog.Id,
                Name = dog.Name,
                UserId = dog.UserId
            };
        }

        public static IDog FromGrpc(this DogModel dog)
        {
            return new Dog()
            {
                Id = dog.Id,
                Name = dog.Name,
                UserId = dog.UserId
            };
        }
    }
}
