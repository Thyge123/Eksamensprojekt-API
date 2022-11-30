using Eksamensprojekt_API.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Eksamensprojekt_API.DBContext
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
    }
}
