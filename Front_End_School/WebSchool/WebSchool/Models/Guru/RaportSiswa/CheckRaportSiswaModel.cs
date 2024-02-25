using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckRaportSiswaModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idPelajaran")]
        public long IdPelajaran { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
    }
}
