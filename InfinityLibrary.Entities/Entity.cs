namespace InfinityLibrary.Entities
{
    public abstract class Entity
    {
        public long Id { get; set; }

        public abstract string ToShortString();
    }
}