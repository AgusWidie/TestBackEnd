using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class KelasInputModel
    {
        [JsonPropertyName("kelas")]
        public int? Kelas { get; set; }
        [JsonPropertyName("namaKelas")]
        public string NamaKelas { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
