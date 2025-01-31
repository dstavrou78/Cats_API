namespace Cats_API.Models
{
    public class Weight
    {
        public int Id { get; set; }
        public string Imperial { get; set; } = string.Empty;
        public string Metric { get; set; } = string.Empty;
        public string? BreedId { get; set; }
        public Breed? Breed { get; set; }
    }
}
