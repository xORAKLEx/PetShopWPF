namespace Interfaces.Models
{
    public interface IUser
    {
        int Id { get; }

        UserType Type { get; }

        string Name { get; }
    }
}
