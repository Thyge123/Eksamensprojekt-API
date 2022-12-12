namespace Eksamensprojekt_API.Model
{
    public class TrashCan
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int? ZipCode { get; set; }
        public bool? isFull { get; set; }
        public int? Estimate { get; set; }
        public DateTime? lastEmptied { get; set; }

        public TrashCan()
        {
        }

        public TrashCan(int id, string city, string address, int zipCode, bool isFull, int estimate, DateTime lastEmptied)
        {
            Id = id;
            City = city;
            Address = address;
            ZipCode = zipCode;
            this.isFull = isFull;
            Estimate = estimate;
            this.lastEmptied = lastEmptied;
        }

        public void ValidateId()
        {
            Console.WriteLine(1);
            if (Id <= 0) throw new ArgumentOutOfRangeException("User must have an Id");
            Console.WriteLine("Internal id " + Id);
        }

        public void ValidateCity()
        {
            if (City == null)
                throw new ArgumentNullException("User must define af city");
            if (City.Length < 1)
                throw new ArgumentOutOfRangeException("");
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
            if (ZipCode <= 3)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidateTrashFull()
        {
            if (isFull == null)
                throw new ArgumentNullException();
        }

        public void ValidateEstimate()
        {
            if (Estimate == null)
                throw new ArgumentNullException();
            if (Estimate <= 0)
                throw new ArgumentOutOfRangeException();
            if (Estimate > 30)
                throw new ArgumentOutOfRangeException();
        }

        public void ValidateLastEmptied()
        {
            if (lastEmptied == null)
                throw new ArgumentNullException();
        }

        public void Validate()
        {
            ValidateId();
            ValidateCity();
            ValidateAddress();
            ValidateZipCode();
            ValidateTrashFull();
            ValidateEstimate();
            ValidateLastEmptied();
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(City)}={City}, {nameof(Address)}={Address}, {nameof(ZipCode)}={ZipCode.ToString()}, {nameof(isFull)}={isFull.ToString()}, {nameof(Estimate)}={Estimate.ToString()}, {nameof(lastEmptied)}={lastEmptied.ToString()}}}";
        }
    }
}