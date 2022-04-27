using Core.Models;
using Interfaces.Models;

namespace Core.Serializers
{
    public class UserSerializer : BaseSerializer<IUser, User>
    {
        protected override string Path => "Users";
    }
}
