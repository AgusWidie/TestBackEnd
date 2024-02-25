using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckPenilaianModel
    {
        [JsonPropertyName("idPelajaran")]
        public long IdPelajaran { get; set; }
        [JsonPropertyName("namaPenilaian")]
        public string NamaPenilaian { get; set; }
    }
}
