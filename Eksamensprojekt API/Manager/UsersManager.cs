using Eksamensprojekt_API.Model;

namespace Eksamensprojekt_API.Manager
{
    public class UsersManager : IUsersManager
    {
        private static int nextId = 1;

        private static readonly List<User> Users = new List<User>
        {
            new User {Id = nextId++, Name = "Bo", PhoneNumber = "12345678", UserName = "Bo", Password = "BoErSej", TrashCanId = 1},
        };

        public User Add(User User)
        {
            User.Id = nextId++;
            Users.Add(User);
            return User;
        }

        public User? Delete(int Id)
        {
            User User = Users.Find(User1 => User1.Id == Id);
            if (User == null) return null;
            Users.Remove(User);
            return User;
        }

        public IEnumerable<User> GetAll(string sortBy = null)
        {
            List<User> data = new List<User>(Users);
            // copy constructor
            // Callers should no get a reference to the Data object, but rather get a copy

            //if (title != null)
            //{
            //    records = records.FindAll(book => book.Title.StartsWith(title));
            //}
            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "id":
                        data = data.OrderBy(User => User.Id).ToList();
                        break;

                    case "name":
                        data = data.OrderBy(User => User.Name).ToList();
                        break;

                    case "TrashCanId":
                        data = data.OrderBy(User => User.TrashCanId).ToList();
                        break;
                }
            }
            return Users;
        }

        public User? GetById(int Id)
        {
            Console.WriteLine("hej");
            return Users.Find(trash => trash.Id == Id);
        }

        public User? Update(int Id, User updates)
        {
            throw new NotImplementedException();
        }
    }
}