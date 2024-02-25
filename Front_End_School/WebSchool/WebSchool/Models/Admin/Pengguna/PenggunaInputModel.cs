using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class PenggunaInputModel
    {
        [JsonPropertyName("namaPengguna")]
        public string NamaPengguna { get; set; }
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
        [JsonPropertyName("pass")]
        public string Pass { get; set; }
        [JsonPropertyName("statusPengguna")]
        public string StatusPengguna { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
