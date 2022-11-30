namespace Eksamensprojekt_API.Model
{
    public class TrashCan
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }
        public bool isFull { get; set; }
        public int Estimate { get; set; }
        public DateTime lastEmptied { get; set; }

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

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(City)}={City}, {nameof(Address)}={Address}, {nameof(ZipCode)}={ZipCode.ToString()}, {nameof(isFull)}={isFull.ToString()}, {nameof(Estimate)}={Estimate.ToString()}, {nameof(lastEmptied)}={lastEmptied.ToString()}}}";
        }
    }
}
