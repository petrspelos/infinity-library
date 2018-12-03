using System.ComponentModel.DataAnnotations;
using InfinityLibrary.Shared.CustomValidation;

namespace InfinityLibrary.Shared.Models
{
    public class UserModel
    {
        public long Id { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Address is required.")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Email address is required.")]
        [EmailAddress(ErrorMessage = "Email address must be in the correct format.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Day of birth is required.")]
        [Range(1, 30, ErrorMessage = "Day of birth must be between 1 and 30 (inclusive).")]
        public int DayOfBirth { get; set; }

        [Required(ErrorMessage = "Month of birth is required.")]
        [Range(1, 12, ErrorMessage = "Month of birth must be between 1 and 12 (inclusive).")]
        public int MonthOfBirth { get; set; }

        [Required(ErrorMessage = "Year of birth is required.")]
        [Range(1849, int.MaxValue, ErrorMessage = "Year of birth must be between 1849 and the current year.")]
        [PastYear(true, ErrorMessage = "Year of birth must be between 1849 and the current year.")]
        public int YearOfBirth { get; set; }

        [Required(ErrorMessage = "Membership expiration day is required.")]
        [Range(1, 30, ErrorMessage = "Membership expiration day must be between 1 and 30 (inclusive).")]
        public int MembershipExpirationDay { get; set; }

        [Required(ErrorMessage = "Membership expiration month is required.")]
        [Range(1, 12, ErrorMessage = "Membership expiration month must be between 1 and 12 (inclusive).")]
        public int MembershipExpirationMonth { get; set; }

        [Required(ErrorMessage = "Membership expiration year is required.")]
        public int MembershipExpirationYear { get; set; }
    }
}