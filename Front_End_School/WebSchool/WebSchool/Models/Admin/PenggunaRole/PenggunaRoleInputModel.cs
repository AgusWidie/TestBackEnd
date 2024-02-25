using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class PenggunaRoleInputModel
    {
        [JsonPropertyName("idPengguna")]
        public long IdPengguna { get; set; }
        [JsonPropertyName("idRole")]
        public long IdRole { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
