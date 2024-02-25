using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class LoginModel
    {
        [JsonPropertyName("apiKey")]
        public string ApiKey { get; set; }
        [JsonPropertyName("namaPengguna")]
        public string NamaPengguna { get; set; }
        [JsonPropertyName("pass")]
        public string Pass { get; set; }
    }
}
