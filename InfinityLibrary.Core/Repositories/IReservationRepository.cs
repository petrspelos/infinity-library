using System.Collections.Generic;
using InfinityLibrary.Core.Entities;

namespace InfinityLibrary.Core.Repositories
{
    public interface IReservationRepository
    {
        IEnumerable<Reservation> GetAll();
    }
}