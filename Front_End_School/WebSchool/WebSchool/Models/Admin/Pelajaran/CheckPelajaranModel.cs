using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckPelajaranModel
    {
        [JsonPropertyName("namaPelajaran")]
        public string NamaPelajaran { get; set; }
    }
}
