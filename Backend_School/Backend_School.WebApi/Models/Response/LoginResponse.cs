using System;

namespace Backend_School.WebApi.Models.Response
{
    public class LoginResponse
    {
        public long Id { get; set; }
        public string NamaPengguna { get; set; }
        public string NamaRole { get; set; }
        public string NamaGuru { get; set; }
        public string Email { get; set; }
    }
}
