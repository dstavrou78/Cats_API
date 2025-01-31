using System.ComponentModel.DataAnnotations;

namespace Cats_API.Models
{
    public class Cat
    {
        [Key]
        public int Id { get; set; }
        public string CatId { get; set; } = string.Empty;
        public int? Width { get; set; }
        public int? Height { get; set; }
        public Image? Image { get; set; }
        public DateTime Created { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }
}
