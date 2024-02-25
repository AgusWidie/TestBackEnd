using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class ConfigurasiPembayaranInputModel
    {
        [JsonPropertyName("namaPembayaran")]
        public string NamaPembayaran { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("kelas")]
        public long Kelas { get; set; }
        [JsonPropertyName("nilaiPembayaran")]
        public long NilaiPembayaran { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
