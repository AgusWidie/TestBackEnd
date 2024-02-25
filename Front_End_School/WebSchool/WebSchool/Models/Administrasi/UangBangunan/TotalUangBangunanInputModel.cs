using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class TotalUangBangunanInputModel
    {
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
    }
}
