namespace Eksamensprojekt_API.Model
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string phoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int TrashCanId   { get; set; }
    }
}
