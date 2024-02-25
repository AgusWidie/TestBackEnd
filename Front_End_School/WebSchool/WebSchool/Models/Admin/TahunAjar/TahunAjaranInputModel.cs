using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class TahunAjaranInputModel
    {
        [JsonPropertyName("tahunAjaran")]
        public string TahunAjaran { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
