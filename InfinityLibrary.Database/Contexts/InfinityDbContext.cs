using Microsoft.EntityFrameworkCore;
using InfinityLibrary.Core.Entities;

namespace InfinityLibrary.Database.Contexts
{
    public class InfinityDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        public InfinityDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
