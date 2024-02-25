using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class MenuRoleInputModel
    {
        [JsonPropertyName("idRole")]
        public long IdRole { get; set; }
        [JsonPropertyName("idMenu")]
        public long IdMenu { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
    }
}
