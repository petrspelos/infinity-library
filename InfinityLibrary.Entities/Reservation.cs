namespace InfinityLibrary.Entities
{
    public class Reservation : Entity
    {
        public long UserId { get; set; }
        public long BookId { get; set; }
    }
}
