using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class PenggunaRoleUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idPengguna")]
        public long IdPengguna { get; set; }
        [JsonPropertyName("idRole")]
        public long IdRole { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
