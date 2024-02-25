using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Backend_School.WebApi.Models
{
    public class ChangePasswordRequest
    {
        public string NamaPengguna { get; set; }
        public string PasswordLama { get; set; }
        public string PasswordBaru { get; set; }
    }
}
