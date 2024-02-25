using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckSiswaModel
    {
        [JsonPropertyName("namaSiswa")]
        public string NamaSiswa { get; set; }
    }
}
