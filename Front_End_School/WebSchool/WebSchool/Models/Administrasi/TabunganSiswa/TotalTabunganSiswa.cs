using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class TotalTabunganSiswa
    {
        [JsonPropertyName("debit")]
        public long Debit { get; set; }
        [JsonPropertyName("credit")]
        public long Credit { get; set; }
    }
}
