using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cats_API.Models
{
    public class Tag
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
        public DateTime Created { get; set; }

        [JsonIgnore]
        public List<Cat> Cats { get; set; } = new List<Cat>();
    }
}
