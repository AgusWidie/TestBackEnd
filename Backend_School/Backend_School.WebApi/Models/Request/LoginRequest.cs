using System;

namespace Backend_School.WebApi.Models.Request
{
    public class LoginRequest
    {
        public string ApiKey { get; set; }
        public string NamaPengguna { get; set; }
        public string Pass { get; set; }
    }
}
