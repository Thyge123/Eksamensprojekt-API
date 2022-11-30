using Eksamensprojekt_API.DBContext;
using Eksamensprojekt_API.Model;

namespace Eksamensprojekt_API.Manager
{
    public class DBTrashCansManager : ITrashCansManager
    {
        private static int nextId = 1;

        private TrashCanContext _trashCanContext;

        public DBTrashCansManager(TrashCanContext trashCanContext)
        {
            _trashCanContext = trashCanContext;
        }

        public TrashCan Add(TrashCan TrashCan)
        {
             TrashCan.Id = ++nextId;
            _trashCanContext.TrashCans.Add(TrashCan);
            _trashCanContext.SaveChanges();
            return TrashCan;

        }

        public TrashCan? Delete(int Id)
        {
            TrashCan? foundTrashCan = GetById(Id);

            if (foundTrashCan != null)
            {
                _trashCanContext.TrashCans.Remove(foundTrashCan);
                _trashCanContext.SaveChanges();
            }
            return foundTrashCan;
        }

        public IEnumerable<TrashCan> GetAll(string sortBy = null)
        {
            IEnumerable<TrashCan> TrashCans = from TrashCan in _trashCanContext.TrashCans
                                    where (sortBy == null)
                                    select TrashCan;
            return TrashCans;
        }

        public TrashCan? GetById(int Id)
        {
              return _trashCanContext.TrashCans.FirstOrDefault(TrashCan => TrashCan.Id == Id);
        }

        public TrashCan? Update(int Id, TrashCan updates)
        {
            TrashCan TrashCanToBeUpdated = GetById(Id);
         

            _trashCanContext.SaveChanges();

            return TrashCanToBeUpdated;
        }
    }
}
