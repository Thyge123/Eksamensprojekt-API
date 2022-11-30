using Eksamensprojekt_API.Model;

namespace Eksamensprojekt_API.Manager
{
    public class TrashCansManager : ITrashCansManager
    {
        private static int nextId = 1;

        private static readonly List<TrashCan> TrashCans = new List<TrashCan>
        {
            new TrashCan {Id = nextId++, City = "Roskilde", Address = "Roskildevej 1", ZipCode = 4000, isFull = true, Estimate = 0, lastEmptied = DateTime.Now},
        };

        public TrashCan Add(TrashCan TrashCan)
        {
            TrashCan.Id = nextId++;
            TrashCans.Add(TrashCan);
            return TrashCan;
        }

        public TrashCan? Delete(int Id)
        {
            TrashCan TrashCan = TrashCans.Find(TrashCan1 => TrashCan1.Id == Id);
            if (TrashCan == null) return null;
            TrashCans.Remove(TrashCan);
            return TrashCan;
        }

        public IEnumerable<TrashCan> GetAll(string sortBy = null)
        {
            List<TrashCan> data = new List<TrashCan>(TrashCans);
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
                        data = data.OrderBy(TrashCan => TrashCan.Id).ToList();
                        break;

                    case "City":
                        data = data.OrderBy(TrashCan => TrashCan.City).ToList();
                        break;

                    case "isFull":
                        data = data.OrderBy(TrashCan => TrashCan.isFull).ToList();
                        break;

                    case "LastEmptied":
                        data = data.OrderBy(TrashCan => TrashCan.lastEmptied).ToList();
                        break;
                }
            }
            return TrashCans;
        }

        public TrashCan? GetById(int Id)
        {
            return TrashCans.Find(trash => trash.Id == Id);
        }

        public TrashCan? Update(int Id, TrashCan updates)
        {
            throw new NotImplementedException();
        }
    }
}