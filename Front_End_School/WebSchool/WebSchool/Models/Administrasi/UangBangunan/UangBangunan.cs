using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class UangBangunan
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("namaSiswa")]
        public string NamaSiswa { get; set; }
        [JsonPropertyName("tanggal")]
        public DateTime? Tanggal { get; set; }
        [JsonPropertyName("nilaiUangBangunan")]
        public long NilaiUangBangunan { get; set; }
        [JsonPropertyName("bayar")]
        public long Bayar { get; set; }
        [JsonPropertyName("totalBayar")]
        public long TotalBayar { get; set; }
        [JsonPropertyName("sisaBayar")]
        public long SisaBayar { get; set; }
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
