using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class RaportSiswaUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idPelajaran")]
        public long IdPelajaran { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("nilai")]
        public decimal? Nilai { get; set; }
        [JsonPropertyName("keterangan")]
        public string Keterangan { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
