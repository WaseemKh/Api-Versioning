using Versioning.Models;

namespace Versioning.Models
{
    public class SpecializationQueryParameters : QueryParameters
    {
        public bool? IsAvailable { get; set; }

        public int? SpecializationId { get; set; }
        public string Name { get; set; } = string.Empty;

        public string SearchTerm { get; set; } = string.Empty;
    }
}
