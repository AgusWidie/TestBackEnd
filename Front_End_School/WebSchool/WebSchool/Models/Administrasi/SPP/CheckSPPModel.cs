using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckSPPModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("tahun")]
        public Int32 Tahun { get; set; }
        [JsonPropertyName("bulan")]
        public Int32 Bulan { get; set; }
    }
}
