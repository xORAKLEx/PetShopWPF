using Interfaces.Models;

namespace Core.Models
{
    public class User : IUser
    {
        public int Id { get; set; }

        public UserType Type { get; set; }

        public string Name { get; set; }
    }
}
