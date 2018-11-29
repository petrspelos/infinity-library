using Microsoft.EntityFrameworkCore;
using InfinityLibrary.Entities;

namespace InfinityLibrary.Server.Models
{
    internal class BookContext : DbContext
    {
        internal DbSet<Book> Book { get; set; }

        internal BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }
    }
}
