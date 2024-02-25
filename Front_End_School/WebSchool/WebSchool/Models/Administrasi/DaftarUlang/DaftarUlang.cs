using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class DaftarUlang
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("namaSiswa")]
        public string NamaSiswa { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("tahunAjaran")]
        public string TahunAjaran { get; set; }
        [JsonPropertyName("idTahunAjaranTo")]
        public long IdTahunAjaranTo { get; set; }
        [JsonPropertyName("tahunAjaranTo")]
        public string TahunAjaranTo { get; set; }
        [JsonPropertyName("idDariKelas")]
        public long IdDariKelas { get; set; }
        [JsonPropertyName("dariKelas")]
        public long DariKelas { get; set; }
        [JsonPropertyName("namaDariKelas")]
        public string NamaDariKelas { get; set; }
        [JsonPropertyName("idKeKelas")]
        public long IdKeKelas { get; set; }
        [JsonPropertyName("keKelas")]
        public long KeKelas { get; set; }
        [JsonPropertyName("namaKeKelas")]
        public string NamaKeKelas { get; set; }
        [JsonPropertyName("nilaiDaftarUlang")]
        public long NilaiDaftarUlang { get; set; }
        [JsonPropertyName("bayar")]
        public long Bayar { get; set; }
        [JsonPropertyName("kembalian")]
        public long Kembalian { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
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
