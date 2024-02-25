using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchPelanggaranSiswa
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
    }
}
