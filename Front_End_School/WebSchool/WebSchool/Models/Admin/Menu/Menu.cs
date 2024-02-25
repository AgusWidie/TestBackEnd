using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class Menu
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idMenuParent")]
        public long IdMenuParent { get; set; }
        [JsonPropertyName("idMenu")]
        public long IdMenu { get; set; }
        [JsonPropertyName("namaMenuParent")]
        public string NamaMenuParent { get; set; }
        [JsonPropertyName("namaMenu")]
        public string NamaMenu { get; set; }
        [JsonPropertyName("namaController")]
        public string NamaController { get; set; }
        [JsonPropertyName("namaAction")]
        public string NamaAction { get; set; }
        [JsonPropertyName("type")]
        public string Type { get; set; }
        [JsonPropertyName("sort")]
        public Int32 Sort { get; set; }
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
