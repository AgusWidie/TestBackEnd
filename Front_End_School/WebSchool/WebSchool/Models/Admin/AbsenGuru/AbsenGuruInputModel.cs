using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class AbsenGuruInputModel
    {
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("namaAbsen")]
        public string NamaAbsen { get; set; }
        [JsonPropertyName("absenMasuk")]
        public TimeSpan AbsenMasuk { get; set; }
        [JsonPropertyName("absenKeluar")]
        public TimeSpan AbsenKeluar { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }

    }
}
