using Core.Models;
using Interfaces.Models;

namespace Core.Serializers
{
    public class DogSerializer : BaseSerializer<IDog, Dog>
    {
        protected override string Path => "Dogs";
    }
}
