using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchAbsenGuru
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("absenMasuk")]
        public DateTime? AbsenMasuk { get; set; }
    }
}
