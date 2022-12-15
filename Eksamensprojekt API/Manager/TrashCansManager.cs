using Eksamensprojekt_API.Model;
using System.Linq;

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
            if (TrashCan.lastEmptied == null)
            {
                TrashCan.lastEmptied = DateTime.Now;
            }
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
            TrashCan? oldTrashCan = GetById(Id);
            if (oldTrashCan == null) return null;
            oldTrashCan.City = updates.City;
            oldTrashCan.Address = updates.Address;
            oldTrashCan.ZipCode = updates.ZipCode;
            oldTrashCan.isFull = updates.isFull;
            oldTrashCan.Estimate = updates.Estimate;
            oldTrashCan.lastEmptied = updates.lastEmptied;
            return oldTrashCan;
        }
    }
}