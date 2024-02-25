using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchAbsenSiswa
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("tanggalAbsen")]
        public DateTime? TanggalAbsen { get; set; }
    }
}
