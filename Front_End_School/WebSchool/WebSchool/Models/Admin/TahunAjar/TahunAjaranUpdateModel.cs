using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class TahunAjaranUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("tahunAjaran")]
        public string TahunAjaran { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
