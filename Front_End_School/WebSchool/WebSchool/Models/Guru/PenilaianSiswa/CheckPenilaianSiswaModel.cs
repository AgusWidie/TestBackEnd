using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckPenilaianSiswaModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idPenilaian")]
        public long IdPenilaian { get; set; }
    }
}
