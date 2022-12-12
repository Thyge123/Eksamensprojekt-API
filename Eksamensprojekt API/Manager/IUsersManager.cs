using Eksamensprojekt_API.Model;

namespace Eksamensprojekt_API.Manager
{
    public interface IUsersManager
    {
        User Add(User User);

        User? GetById(int Id);

        User? Update(int Id, User updates);

        User? Delete(int Id);

        IEnumerable<User> GetAll(string sortBy = null);
    }
}