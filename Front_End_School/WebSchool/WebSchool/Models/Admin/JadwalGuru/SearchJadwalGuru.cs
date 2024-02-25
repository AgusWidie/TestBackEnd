using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchJadwalGuru
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idPelajaran")]
        public long IdPelajaran { get; set; }
    }
}
