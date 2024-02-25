using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class ChangePassword
    {
        [JsonPropertyName("namaPengguna")]
        public string NamaPengguna { get; set; }
        [JsonPropertyName("passwordLama")]
        public string PasswordLama { get; set; }
        [JsonPropertyName("passwordBaru")]
        public string PasswordBaru { get; set; }
    }
}
