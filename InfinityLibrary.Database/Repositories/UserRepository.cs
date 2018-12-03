using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Database.Contexts;

namespace InfinityLibrary.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InfinityDbContext _context;

        public UserRepository(InfinityDbContext context)
        {
            _context = context;
        }
    }
}