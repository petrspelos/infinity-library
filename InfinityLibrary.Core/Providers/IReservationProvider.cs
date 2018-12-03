using System.Collections.Generic;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Core.Providers
{
    public interface IReservationProvider
    {
        IEnumerable<ReservationModel> GetAll();
    }
}