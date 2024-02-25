using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchUangBangunan
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long idKelas { get; set; }
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
    }
}
