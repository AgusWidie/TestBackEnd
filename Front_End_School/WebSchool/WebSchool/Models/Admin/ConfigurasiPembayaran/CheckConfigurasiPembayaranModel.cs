using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckConfigurasiPembayaranModel
    {
        [JsonPropertyName("namaPembayaran")]
        public string NamaPembayaran { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
    }
}
