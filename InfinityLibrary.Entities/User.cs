using System;
using System.Text;

namespace InfinityLibrary.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime MembershipValidTill { get; set; }

        public override string ToString()
        {
            return new StringBuilder()
                .AppendLine($"{FirstName} {LastName}")
                .AppendLine($"{Email}")
                .AppendLine($"Address: {Address}")
                .AppendLine($"Date of birth: {DateOfBirth.ToShortDateString()}")
                .AppendLine($"Membership valid till: {MembershipValidTill.ToShortDateString()}")
                .ToString();
        }

        public override string ToShortString()
        {
            return $"{FirstName} {LastName} ({Email})";
        }
    }
}