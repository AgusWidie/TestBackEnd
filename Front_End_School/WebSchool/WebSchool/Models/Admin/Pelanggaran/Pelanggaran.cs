using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class Pelanggaran
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("namaPelanggaran")]
        public string NamaPelanggaran { get; set; }
        [JsonPropertyName("poin")]
        public long? Poin { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("penggunaBuat")]
        public string PenggunaBuat { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
        [JsonPropertyName("tanggalBuat")]
        public DateTime? TanggalBuat { get; set; }
        [JsonPropertyName("penggunaPerbarui")]
        public string PenggunaPerbarui { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
        [JsonPropertyName("tanggalPerbarui")]
        public DateTime? TanggalPerbarui { get; set; }
    }
}
