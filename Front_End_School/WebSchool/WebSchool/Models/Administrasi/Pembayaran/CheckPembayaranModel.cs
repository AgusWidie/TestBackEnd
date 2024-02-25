using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckPembayaranModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idConfigPembayaran")]
        public long IdConfigPembayaran { get; set; }
    }
}
