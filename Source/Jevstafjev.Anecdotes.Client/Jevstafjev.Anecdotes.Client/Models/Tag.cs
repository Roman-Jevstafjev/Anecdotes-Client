namespace Jevstafjev.Anecdotes.Client.Models
{
    public class Tag
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public int AnecdotesCount { get; set; }
    }
}