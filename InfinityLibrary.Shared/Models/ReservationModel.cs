using System.ComponentModel.DataAnnotations;

namespace InfinityLibrary.Shared.Models
{
    public class ReservationModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "User ID is required.")]
        public long UserId { get; set; }

        [Required(ErrorMessage = "Book ID is required.")]
        public long BookId { get; set; }

        public int ReservationDay { get; set; }

        public int ReservationMonth { get; set; }

        public int ReservationYear { get; set; }
    }
}