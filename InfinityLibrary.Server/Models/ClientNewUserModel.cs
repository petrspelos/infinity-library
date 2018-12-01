using System.ComponentModel.DataAnnotations;

namespace InfinityLibrary.Server.Models
{
    public class ClientNewUserModel
    {
        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Range(1, 30)]
        public int DayOfBirth { get; set; }

        [Required]
        [Range(1, 12)]
        public int MonthOfBirth { get; set; }

        [Required]
        public int YearOfBirth { get; set; }

        [Required]
        public string Address { get; set; }
    }
}