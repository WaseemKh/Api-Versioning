
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Versioning.Models
{
    public class Doctor
    {
        public int Id { get; set; }
      
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public bool IsAvailable { get; set; }

        [Required]
        public int SpecializationId { get; set; }
        [JsonIgnore]
        public virtual Specialization? Specialization { get; set; }
    }
}
