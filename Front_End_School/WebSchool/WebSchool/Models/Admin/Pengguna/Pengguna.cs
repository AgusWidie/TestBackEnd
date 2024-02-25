using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class Pengguna
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("namaPengguna")]
        public string NamaPengguna { get; set; }
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
        [JsonPropertyName("namaGuru")]
        public string NamaGuru { get; set; }
        [JsonPropertyName("statusPengguna")]
        public string StatusPengguna { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("expiredPassword")]
        public DateTime? ExpiredPassword { get; set; }
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
