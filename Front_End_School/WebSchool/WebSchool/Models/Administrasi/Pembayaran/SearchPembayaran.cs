using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SearchPembayaran
    {
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("kelas")]
        public Int32 kelas { get; set; }
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
    }
}
