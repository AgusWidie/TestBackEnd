using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckPenggunaModel
    {
        [JsonPropertyName("namaPengguna")]
        public string NamaPengguna { get; set; }
        [JsonPropertyName("idGuru")]
        public long IdGuru { get; set; }
    }
}
