namespace InfinityLibrary.Entities
{
    public class Reservation
    {
        public ulong Id { get; set; }
        public ulong UserId { get; set; }
        public ulong BookId { get; set; }
    }
}