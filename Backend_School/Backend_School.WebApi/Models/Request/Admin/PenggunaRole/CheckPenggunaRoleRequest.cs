using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckPenggunaRoleRequest
    {
        public long IdPengguna { get; set; }
        public long IdRole { get; set; }
    }
}
