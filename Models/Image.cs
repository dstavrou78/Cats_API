using System.Text.Json.Serialization;

namespace Cats_API.Models
{
    public class Image
    {
        public string Id { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public int? Width { get; set; }
        public int? Height { get; set; }
        public int CatId { get; set; }
        [JsonIgnore]
        public Cat? Cat { get; set; }
        public List<Breed>? Breeds { get; set; } = new List<Breed>();
    }
}
