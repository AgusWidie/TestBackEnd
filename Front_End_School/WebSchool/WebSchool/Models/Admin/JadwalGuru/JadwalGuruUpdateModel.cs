using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class JadwalGuruUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
        [JsonPropertyName("hari")]
        public string Hari { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idPelajaran")]
        public long IdPelajaran { get; set; }
        [JsonPropertyName("idTahunajaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("dariJam")]
        public TimeSpan? DariJam { get; set; }
        [JsonPropertyName("sampaiJam")]
        public TimeSpan? SampaiJam { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
