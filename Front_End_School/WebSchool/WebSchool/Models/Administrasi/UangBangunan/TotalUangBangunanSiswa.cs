using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class TotalUangBangunanSiswa
    {
        [JsonPropertyName("totalBayarUangBangunan")]
        public long TotalBayarUangBangunan { get; set; }
    }
}
