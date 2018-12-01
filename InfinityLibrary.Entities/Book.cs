namespace InfinityLibrary.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int Copies { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
