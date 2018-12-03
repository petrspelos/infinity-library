using System;

namespace InfinityLibrary.Shared.Models
{
    public class ReservationViewModel
    {
        public long Id { get; set; }
        public UserModel RenterModel { get; set; }
        public BookModel RentedBookModel { get; set; }
        public DateTime Date { get; set; }
    }
}