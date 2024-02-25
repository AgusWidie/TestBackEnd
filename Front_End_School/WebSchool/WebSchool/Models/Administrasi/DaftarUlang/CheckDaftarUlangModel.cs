using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckDaftarUlangModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("kelasTahunAjaran")]
        public long KelasTahunAjaran { get; set; }
        [JsonPropertyName("idTahunAjaranTo")]
        public long IdTahunAjaranTo { get; set; }
        [JsonPropertyName("kelasTahunAjaranTo")]
        public long KelasTahunAjaranTo { get; set; }

    }
}
