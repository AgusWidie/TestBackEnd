using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchConfigPembayaran
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("kelas")]
        public int Kelas { get; set; }
    }
}
