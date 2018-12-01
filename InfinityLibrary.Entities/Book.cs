namespace InfinityLibrary.Entities
{
    public class Book
    {
        public long Id { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public uint Copies { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
