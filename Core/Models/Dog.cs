using Interfaces.Models;

namespace Core.Models
{
    public class Dog : IDog
    {
        public int Id { get; set; }

        public  int UserId { get; set; }

        public string Name { get; set; }
    }
}
