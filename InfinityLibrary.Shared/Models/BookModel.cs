using InfinityLibrary.Shared.CustomValidation;
using System.ComponentModel.DataAnnotations;

namespace InfinityLibrary.Shared.Models
{
    public class BookModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [MaxLength(100, ErrorMessage = "Title cannot be longer than 100 characters.")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Genre is required.")]
        [MaxLength(100, ErrorMessage = "Genre cannot be longer than 100 characters.")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "Author is required.")]
        [MaxLength(100, ErrorMessage = "Author cannot be longer than 100 characters.")]
        public string Author { get; set; }

        [Required(ErrorMessage = "Publication year is required.")]
        [PastYear(true, ErrorMessage = "Publication year must be in the past.")]
        public int PublicationYear { get; set; }

        [Required(ErrorMessage = "Number of copies is required.")]
        [Range(0, int.MaxValue, ErrorMessage = "Number of copies must be a positive number.")]
        public int Copies { get; set; }

        [Required(ErrorMessage = "Thumbnail URL is required.")]
        public string ThumbnailUrl { get; set; }
    }
}
