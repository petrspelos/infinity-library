using System;
using InfinityLibrary.Entities;

namespace InfinityLibrary.Shared.SharedModels
{
    public class ReservedBookModel : Book
    {
        public long ReservationId { get; set; }
        public DateTime ReservationDate { get; set; }
    }
}