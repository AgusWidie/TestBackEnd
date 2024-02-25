using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckAddAbsenGuruModel
    {
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("tanggalAbsen")]
        public DateTime? TanggalAbsen { get; set; }
    }
}
