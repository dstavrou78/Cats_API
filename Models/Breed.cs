using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Cats_API.Models
{
    public class Breed
    {
        [Key]
        public string Id { get; set; } = string.Empty;
        public Weight? Weight { get; set; } = null;
        [Required]
        public string Name { get; set; } = string.Empty;
        public string Temperament { get; set; } = string.Empty;
        public string Origin { get; set; } = string.Empty;
        public string Country_codes { get; set; } = string.Empty;
        public string Country_code { get; set; } = string.Empty;
        public string Life_span { get; set; } = string.Empty;
        public string Wikipedia_url { get; set; } = string.Empty;
        public string Vetstreet_url { get; set; } = string.Empty;
        public string Vcahospitals_url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Alt_names { get; set; } = string.Empty;

        [Range(0, 5, ErrorMessage = "Value of Indoor property must be between 0 and 5")]
        public int? Indoor { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Adaptability property must be between 0 and 5")]
        public int? Adaptability { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Affection_level property must be between 0 and 5")]
        public int? Affection_level { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Child_friendly property must be between 0 and 5")]
        public int? Child_friendly { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Dog_friendly property must be between 0 and 5")]
        public int? Dog_friendly { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Energy_level property must be between 0 and 5")]
        public int? Energy_level { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Grooming property must be between 0 and 5")]
        public int? Grooming { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Health_issues property must be between 0 and 5")]
        public int? Health_issues { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Intelligence property must be between 0 and 5")]
        public int? Intelligence { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Shedding_level property must be between 0 and 5")]
        public int? Shedding_level { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Social_needs property must be between 0 and 5")]
        public int? Social_needs { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Stranger_friendly property must be between 0 and 5")]
        public int? Stranger_friendly { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Experimental property must be between 0 and 5")]
        public int? Experimental { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Hairless property must be between 0 and 5")]
        public int? Hairless { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Natural property must be between 0 and 5")]
        public int? Natural { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Rare property must be between 0 and 5")]
        public int? Rare { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Rex property must be between 0 and 5")]
        public int? Rex { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Suppressed_tail property must be between 0 and 5")]
        public int? Suppressed_tail { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Short_legs property must be between 0 and 5")]
        public int? Short_legs { get; set; }

        [Range(0, 5, ErrorMessage = "Value of Hypoallergenic property must be between 0 and 5")]
        public int? Hypoallergenic { get; set; }
        public string Reference_image_id { get; set; } = string.Empty;
        [JsonIgnore]
        public List<Image>? Images { get; set; } = new List<Image>();
    }
}
