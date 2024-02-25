using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class IdConfigPembayaran
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}
