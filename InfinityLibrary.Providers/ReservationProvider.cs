using System.Collections.Generic;
using InfinityLibrary.Core.Providers;
using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Providers
{
    public class ReservationProvider : IReservationProvider
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationProvider(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public IEnumerable<ReservationModel> GetAll()
        {
            return _reservationRepository.GetAll().Select(ReservationModelConvertor.ToModel);
        }
    }
}