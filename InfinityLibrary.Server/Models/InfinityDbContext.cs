using Microsoft.EntityFrameworkCore;
using InfinityLibrary.Entities;

namespace InfinityLibrary.Server.Models
{
    public class InfinityDbContext : DbContext
    {
        public DbSet<Book> Book { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Reservation> Reservation { get; set; }

        public InfinityDbContext(DbContextOptions<InfinityDbContext> options) : base(options)
        {
        }
    }
}
