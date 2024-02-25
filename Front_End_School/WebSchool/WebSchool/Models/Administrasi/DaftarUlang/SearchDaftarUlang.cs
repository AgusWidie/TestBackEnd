using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchDaftarUlang
    {
        [JsonPropertyName("idTahunAjaranTo")]
        public long IdTahunAjaranTo { get; set; }
        [JsonPropertyName("idKeKelas")]
        public long IdKeKelas { get; set; }
    }
}
