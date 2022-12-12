using Eksamensprojekt_API.Model;
using Microsoft.EntityFrameworkCore;

namespace Eksamensprojekt_API.DBContext
{
    public class TrashCanContext : DbContext
    {
        public TrashCanContext(DbContextOptions<TrashCanContext> options) : base(options)  { }

        public DbSet<TrashCan> TrashCans { get; set; }
    }
}