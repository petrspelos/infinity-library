using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityLibrary.Core.Entities;
using InfinityLibrary.Core.Providers;
using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Providers.TypeConvertors;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Providers
{
    public class ReservationProvider : IReservationProvider
    {
        private readonly IReservationRepository _reservationRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IUserRepository _userRepository;

        public ReservationProvider(IReservationRepository reservationRepository, IBookRepository bookRepository, IUserRepository userRepository)
        {
            _reservationRepository = reservationRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public IEnumerable<ReservationModel> GetAll()
        {
            return _reservationRepository.GetAll().Select(ReservationModelConvertor.ToModel);
        }

        public IEnumerable<ReservationViewModel> GetAllViewModels()
        {
            var reservations = _reservationRepository.GetAll();
            // TODO: finish
            throw new System.NotImplementedException();
        }

        private async Task<ReservationViewModel> ReservationToViewModel(Reservation reservation)
        {
            return new ReservationViewModel
            {
                Id = reservation.Id,
                Date = reservation.Date,
                RenterModel = (await _userRepository.GetById(reservation.UserId)).ToModel(),
                RentedBookModel = _bookRepository.GetById(reservation.BookId).ToModel()
            };
        }
    }
}