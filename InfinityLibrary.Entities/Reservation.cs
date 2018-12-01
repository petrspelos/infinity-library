namespace InfinityLibrary.Entities
{
    public class Reservation : Entity
    {
        public long UserId { get; set; }
        public long BookId { get; set; }

        public override string ToString()
        {
            return $"User:{{{UserId}}} - Book:{{{BookId}}}";
        }

        public override string ToShortString()
        {
            return ToString();
        }
    }
}