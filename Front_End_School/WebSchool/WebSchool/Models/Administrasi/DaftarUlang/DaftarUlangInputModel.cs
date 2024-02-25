using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class DaftarUlangInputModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idTahunAjaranTo")]
        public long IdTahunAjaranTo { get; set; }
        [JsonPropertyName("idDariKelas")]
        public long IdDariKelas { get; set; }
        [JsonPropertyName("dariKelas")]
        public long DariKelas { get; set; }
        [JsonPropertyName("idKeKelas")]
        public long IdKeKelas { get; set; }
        [JsonPropertyName("keKelas")]
        public long KeKelas { get; set; }
        [JsonPropertyName("namaPembayaran")]
        public long NamaPembayaran { get; set; }
        [JsonPropertyName("nilaiDaftarUlang")]
        public long NilaiDaftarUlang { get; set; }
        [JsonPropertyName("bayar")]
        public long Bayar { get; set; }
        [JsonPropertyName("kembalian")]
        public long Kembalian { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
