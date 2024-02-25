using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class ApiKeyModel
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }
    }
}
