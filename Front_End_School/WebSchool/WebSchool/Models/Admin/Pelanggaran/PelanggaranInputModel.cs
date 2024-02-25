using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class PelanggaranInputModel
    {
        [JsonPropertyName("namaPelanggaran")]
        public string NamaPelanggaran { get; set; }
        [JsonPropertyName("poin")]
        public long? Poin { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
