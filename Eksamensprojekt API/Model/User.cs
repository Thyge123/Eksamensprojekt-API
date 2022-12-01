namespace Eksamensprojekt_API.Model
{
    public class User
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? ZipCode { get; set; }
        public string phoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public int? TrashCanId   { get; set; }

        public User()
        {

        }

        public User(int id, string name, string city, string address, int zipCode, string PhoneNumber, string userName, string password, int trashCanId)
        {
            Id = id;
            Name = name;
            City = city;
            Address = address;
            ZipCode = zipCode;
            phoneNumber = PhoneNumber;
            UserName = userName;
            Password = password;
            TrashCanId = trashCanId;
        }

        public void ValidateId()
        {
            if (Id <= 0)
                throw new ArgumentOutOfRangeException();
            if (Id == null)
                throw new ArgumentNullException("id");
        }

        public void ValidateName()
        {
            if (Name == null)
                throw new ArgumentNullException();
            if (Name.Length <= 1)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidateCity()
        {
            if (City == null)
                throw new ArgumentNullException();
            if (City.Length <= 1)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidateAddress()
        {
            if (Address == null)
                throw new ArgumentNullException();
            if (Address.Length < 1)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidateZipCode()
        {
            if (ZipCode == null)
                throw new ArgumentNullException();
            if (ZipCode < 3)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidatePhoneNumber()
        {
            if (phoneNumber == null)
                throw new ArgumentNullException();
            if (phoneNumber.Length <= 7)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidateUserName()
        {
            if (UserName == null)
                throw new ArgumentNullException();
            if (UserName.Length < 1)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidatePassword()
        {
            if (Password == null)
                throw new ArgumentNullException();
            if (Password.Length < 5)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidateTrashId()
        {
            if (TrashCanId == null)
                throw new ArgumentNullException();
            if (TrashCanId <= 0)
                throw new ArgumentOutOfRangeException();
        }

        public void Validate()
        {
            ValidateId();
            ValidateName();
            ValidateCity();
            ValidateAddress();
            ValidateZipCode();
            ValidatePhoneNumber();
            ValidateUserName();
            ValidatePassword();
            ValidateTrashId();

        }
    }
}
