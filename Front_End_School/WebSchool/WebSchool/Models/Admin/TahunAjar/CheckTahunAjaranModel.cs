using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckTahunAjaranModel
    {
        [JsonPropertyName("tahunAjaran")]
        public string TahunAjaran { get; set; }
    }
}
