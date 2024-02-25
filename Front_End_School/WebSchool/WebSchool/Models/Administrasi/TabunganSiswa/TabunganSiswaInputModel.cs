using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class TabunganSiswaInputModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("debit")]
        public long Debit { get; set; }
        [JsonPropertyName("credit")]
        public long Credit { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
