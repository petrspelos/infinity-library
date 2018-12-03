namespace InfinityLibrary.Core.Entities
{
    public class Book : Entity
    {
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public int Copies { get; set; }
        public string ThumbnailUrl { get; set; }

        public override string ToString()
        {
            return $"{Title} ({Genre}) by {Author}, {PublicationYear}. ({Copies} in this library)";
        }

        public override string ToShortString()
        {
            return $"{Title} by {Author}";
        }
    }
}
