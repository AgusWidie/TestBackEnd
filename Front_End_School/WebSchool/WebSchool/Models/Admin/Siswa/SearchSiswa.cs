using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchSiswa
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
    }
}
