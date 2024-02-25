using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckGuruModel
    {
        [JsonPropertyName("noKtp")]
        public string NoKTP { get; set; }
    }
}
