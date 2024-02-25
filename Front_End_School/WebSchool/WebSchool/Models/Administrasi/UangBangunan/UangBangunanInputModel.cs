using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class UangBangunanInputModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long idKelas { get; set; }
        [JsonPropertyName("tanggal")]
        public DateTime? Tanggal { get; set; }
        [JsonPropertyName("namaPembayaran")]
        public long NamaPembayaran { get; set; }
        [JsonPropertyName("nilaiUangBangunan")]
        public long NilaiUangBangunan { get; set; }
        [JsonPropertyName("bayar")]
        public long Bayar { get; set; }
        [JsonPropertyName("totalBayar")]
        public long TotalBayar { get; set; }
        [JsonPropertyName("sisaBayar")]
        public long SisaBayar { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
