using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class CheckPenggunaRoleModel
    {
        [JsonPropertyName("idPengguna")]
        public long IdPengguna { get; set; }
        [JsonPropertyName("idRole")]
        public long IdRole { get; set; }
    }
}
