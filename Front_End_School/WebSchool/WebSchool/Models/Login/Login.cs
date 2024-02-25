using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class Login
    {
        [JsonPropertyName("namaPengguna")]
        public string NamaPengguna { get; set; }
        [JsonPropertyName("namaRole")]
        public string NamaRole { get; set; }
        [JsonPropertyName("token")]
        public string Token { get; set; }
        [JsonPropertyName("expiredToken")]
        public DateTime? ExpiredToken { get; set; }
    }
}
