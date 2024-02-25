using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckPelanggaranModel
    {
        [JsonPropertyName("namaPelanggaran")]
        public string NamaPelanggaran { get; set; }
    }
}
