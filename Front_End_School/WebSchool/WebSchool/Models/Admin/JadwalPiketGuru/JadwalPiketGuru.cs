using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class JadwalPiketGuru
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("tahunAjaran")]
        public string TahunAjaran { get; set; }
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
        [JsonPropertyName("namaGuru")]
        public string NamaGuru { get; set; }
        [JsonPropertyName("hari")]
        public string Hari { get; set; }
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
