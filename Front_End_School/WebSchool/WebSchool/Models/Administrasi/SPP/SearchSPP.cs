using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchSPP
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("tahun")]
        public Int32 Tahun { get; set; }
        [JsonPropertyName("namaBulan")]
        public string NamaBulan { get; set; }
    }
}
