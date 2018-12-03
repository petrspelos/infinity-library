using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Database.Contexts;

namespace InfinityLibrary.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly InfinityDbContext _context;

        public BookRepository(InfinityDbContext context)
        {
            _context = context;
        }
    }
}