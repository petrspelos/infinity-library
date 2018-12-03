using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityLibrary.Core.Entities;
using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InfinityLibrary.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly InfinityDbContext _context;

        public UserRepository(InfinityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetAll()
        {
            return _context.User;
        }

        public IEnumerable<User> GetAllWithMembership()
        {
            return _context.User.Where(u => u.HasValidMembership);
        }

        public async Task<User> GetById(long id)
        {
            return await _context.User.FindAsync(id);
        }

        public async Task Update(User user)
        {
            _context.Entry(user).State = EntityState.Modified;
            await SaveContextChangesOrThrow();
        }

        public async Task Add(User user)
        {
            _context.User.Add(user);
            await SaveContextChangesOrThrow();
        }

        public async Task DeleteById(long id)
        {
            var user = await _context.User.FindAsync(id);
            if (user is null)
            {
                throw new InvalidOperationException("The user you are trying to delete could not be found.");
            }

            if (_context.Reservation.Any(r => r.UserId == id))
            {
                throw new InvalidOperationException("Could not delete the user, because they have an active reservation.");
            }

            _context.User.Remove(user);
            await SaveContextChangesOrThrow();
        }

        private async Task SaveContextChangesOrThrow()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Saving changes to the database failed. Please try again in a little bit.");
            }
        }
    }
}