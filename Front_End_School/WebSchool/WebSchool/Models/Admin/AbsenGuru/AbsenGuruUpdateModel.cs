using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class AbsenGuruUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("namaAbsen")]
        public string NamaAbsen { get; set; }
        [JsonPropertyName("absenMasuk")]
        public TimeSpan? AbsenMasuk { get; set; }
        [JsonPropertyName("absenKeluar")]
        public TimeSpan? AbsenKeluar { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
