using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class ConfigurasiPembayaranUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
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
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
