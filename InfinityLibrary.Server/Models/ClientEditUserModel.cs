using System.ComponentModel.DataAnnotations;

namespace InfinityLibrary.Server.Models
{
    public class ClientEditUserModel : ClientNewUserModel
    {
        [Required]
        [Range(1, 30)]
        public int MembershipEndDay { get; set; }

        [Required]
        [Range(1, 12)]
        public int MembershipEndMonth { get; set; }

        [Required]
        public int MembershipEndYear { get; set; }
    }
}