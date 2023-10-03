using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace qa_server.Models
{
    public class Answer
    {
        [JsonProperty(PropertyName = "id")]
        public string? Id { get; set; } = default;

        [JsonProperty(PropertyName = "owner")]
        public string? Owner { get; set; }

        [JsonProperty(PropertyName = "questionId")]
        [Required]
        public string QuestionId { get; set; }

        [JsonProperty(PropertyName = "description")]
        [Required]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTime? CreatedOn { get; set; }

        [JsonProperty(PropertyName = "updatedOn")]
        public DateTime? UpdatedOn { get; set; }
    }
}
