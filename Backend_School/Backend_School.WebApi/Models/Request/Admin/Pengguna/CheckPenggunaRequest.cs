using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckPenggunaRequest
    {
        public string NamaPengguna { get; set; }
        public long IdGuru { get; set; }
    }
}
