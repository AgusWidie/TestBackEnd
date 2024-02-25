using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class MenuRoleUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idRole")]
        public long IdRole { get; set; }
        [JsonPropertyName("idMenu")]
        public long IdMenu { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
