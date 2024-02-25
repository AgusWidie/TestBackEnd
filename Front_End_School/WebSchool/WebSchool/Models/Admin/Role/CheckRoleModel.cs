using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckRoleModel
    {
        [JsonPropertyName("namaRole")]
        public string NamaRole { get; set; }
    }
}
