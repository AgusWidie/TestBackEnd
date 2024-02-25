using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class AbsenSiswaUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
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
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
