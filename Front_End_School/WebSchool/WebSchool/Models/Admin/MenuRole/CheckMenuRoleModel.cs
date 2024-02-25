using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckMenuRoleModel
    {
        [JsonPropertyName("idRole")]
        public long IdRole { get; set; }
        [JsonPropertyName("idMenu")]
        public long IdMenu { get; set; }
    }
}
