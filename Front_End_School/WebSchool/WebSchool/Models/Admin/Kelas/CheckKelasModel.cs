using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckKelasModel
    {
        [JsonPropertyName("namaKelas")]
        public string NamaKelas { get; set; }
    }
}
