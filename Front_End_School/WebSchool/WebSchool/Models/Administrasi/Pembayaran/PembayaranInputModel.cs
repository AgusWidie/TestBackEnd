using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class PembayaranInputModel
    {
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
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
