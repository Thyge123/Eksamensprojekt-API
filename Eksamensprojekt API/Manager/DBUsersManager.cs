using Eksamensprojekt_API.DBContext;
using Eksamensprojekt_API.Model;

namespace Eksamensprojekt_API.Manager
{
    public class DBUsersManager : IUsersManager
    {
        private static int nextId = 1;

        private UserContext _UserContext;

        public DBUsersManager(UserContext UserContext)
        {
            _UserContext = UserContext;
        }

        public User Add(User User)
        {
            User.Id = ++nextId;
            _UserContext.Users.Add(User);
            _UserContext.SaveChanges();
            return User;
        }

        public User? Delete(int Id)
        {
            User? foundUser = GetById(Id);

            if (foundUser != null)
            {
                _UserContext.Users.Remove(foundUser);
                _UserContext.SaveChanges();
            }
            return foundUser;
        }

        public IEnumerable<User> GetAll(string sortBy = null)
        {
            IEnumerable<User> Users = from User in _UserContext.Users
                                      where (sortBy == null)
                                      select User;
            return Users;
        }

        public User? GetById(int Id)
        {
            return _UserContext.Users.FirstOrDefault(User => User.Id == Id);
        }

        public User? Update(int Id, User updates)
        {
            User UserToBeUpdated = GetById(Id);

            _UserContext.SaveChanges();

            return UserToBeUpdated;
        }
    }
}