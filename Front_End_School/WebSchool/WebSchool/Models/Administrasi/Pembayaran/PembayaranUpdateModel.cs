using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class PembayaranUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idConfigPembayaran")]
        public long IdConfigPembayaran { get; set; }
        [JsonPropertyName("nilaiPembayaran")]
        public long NilaiPembayaran { get; set; }
        [JsonPropertyName("bayar")]
        public long Bayar { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
