using Eksamensprojekt_API.Model;

namespace Eksamensprojekt_API.Manager
{
    public interface ITrashCansManager
    {
        TrashCan Add(TrashCan TrashCan);

        TrashCan? GetById(int Id);

        TrashCan? Update(int Id, TrashCan updates);

        TrashCan? Delete(int Id);

        IEnumerable<TrashCan> GetAll(string sortBy = null);
    }
}