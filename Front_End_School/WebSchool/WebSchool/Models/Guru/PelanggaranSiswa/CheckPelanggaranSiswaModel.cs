using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckPelanggaranSiswaModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idPelanggaran")]
        public long IdPelanggaran { get; set; }
    }
}
