using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckMenuRoleRequest
    {
        public long IdRole { get; set; }
        public long IdMenu { get; set; }
    }
}
