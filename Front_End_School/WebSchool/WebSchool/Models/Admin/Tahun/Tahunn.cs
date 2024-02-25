using System.Text.Json.Serialization;

namespace WebSchool.Models.Admin.Tahun
{
    public class Tahunn
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("tahun")]
        public int Tahun { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
    }
}
