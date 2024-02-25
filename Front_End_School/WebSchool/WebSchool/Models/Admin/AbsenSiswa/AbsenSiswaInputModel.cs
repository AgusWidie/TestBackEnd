using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class AbsenSiswaInputModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("namaAbsen")]
        public string NamaAbsen { get; set; }
        [JsonPropertyName("tanggalAbsen")]
        public DateTime? TanggalAbsen { get; set; }
        [JsonPropertyName("deskripsi")]
        public string Deskripsi { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
