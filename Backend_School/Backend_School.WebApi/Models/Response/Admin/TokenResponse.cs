using System;

namespace Backend_School.WebApi.Models.Response
{
    public class TokenResponse
    {
        public string NamaPengguna { get; set; }
        public string NamaRole { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiredToken { get; set; }
    }
}
