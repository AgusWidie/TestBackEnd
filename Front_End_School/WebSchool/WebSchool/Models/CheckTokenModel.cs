using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckTokenModel
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }
        [JsonPropertyName("namaPengguna")]
        public string NamaPengguna { get; set; }
    }
}
