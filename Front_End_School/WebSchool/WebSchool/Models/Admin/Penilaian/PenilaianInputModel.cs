using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class PenilaianInputModel
    {
        [JsonPropertyName("idPelajaran")]
        public long IdPelajaran { get; set; }
        [JsonPropertyName("namaPenilaian")]
        public string NamaPenilaian { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
