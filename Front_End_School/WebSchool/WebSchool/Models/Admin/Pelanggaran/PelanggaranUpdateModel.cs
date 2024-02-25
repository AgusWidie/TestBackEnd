using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class PelanggaranUpdateModel
    {
        [JsonPropertyName("id")]
        public long? Id { get; set; }
        [JsonPropertyName("namaPelanggaran")]
        public string NamaPelanggaran { get; set; }
        [JsonPropertyName("poin")]
        public long? Poin { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
