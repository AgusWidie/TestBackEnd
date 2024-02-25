using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class RaportSiswaInputModel
    {
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
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
