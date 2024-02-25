using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckWaliKelasModel
    {
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
    }
}
