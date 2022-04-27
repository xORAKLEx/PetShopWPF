namespace Interfaces.Models
{
    public interface IDog
    {
        int Id { get; }

        int UserId { get; set; }

        string Name { get; }
    }
}
