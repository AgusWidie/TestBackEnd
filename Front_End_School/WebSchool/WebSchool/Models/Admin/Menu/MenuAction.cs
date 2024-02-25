using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class MenuAction
    {
        [JsonPropertyName("controllerName")]
        public string ControllerName { get; set; }
    }
}
