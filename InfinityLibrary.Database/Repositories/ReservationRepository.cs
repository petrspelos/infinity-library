using System.Collections.Generic;
using InfinityLibrary.Core.Entities;
using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Database.Contexts;

namespace InfinityLibrary.Database.Repositories
{
    public class ReservationRepository : IReservationRepository
    {
        private readonly InfinityDbContext _context;

        public ReservationRepository(InfinityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Reservation> GetAll()
        {
            return _context.Reservation;
        }
    }
}