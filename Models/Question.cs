using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace qa_server.Models
{
    public class Question
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; } = default;

        [JsonProperty(PropertyName = "owner")]
        public string? Owner { get; set; }

        [JsonProperty(PropertyName = "heading")]
        [Required]
        public string Heading { get; set; }

        [JsonProperty(PropertyName = "description")]
        [Required]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "tag")]
        [Required]
        public string Tag { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime? CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedOn")]
        public DateTime? UpdatedOn { get; set; }
    }
}
