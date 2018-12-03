﻿using InfinityLibrary.Core.Providers;
using InfinityLibrary.Core.Repositories;

namespace InfinityLibrary.Providers
{
    public class ReservationProvider : IReservationProvider
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationProvider(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }
    }
}