using InfinityLibrary.Core.Entities;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Providers.TypeConvertors
{
    internal static class ReservationModelConvertor
    {
        internal static ReservationModel ToModel(this Reservation reservation)
        {
            return new ReservationModel
            {
                Id = reservation.Id,
                BookId = reservation.BookId,
                UserId = reservation.UserId,
                ReservationDay = reservation.Date.Day,
                ReservationMonth = reservation.Date.Month,
                ReservationYear = reservation.Date.Year
            };
        }
    }
}