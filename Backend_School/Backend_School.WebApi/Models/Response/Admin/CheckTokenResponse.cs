using System;

namespace Backend_School.WebApi.Models.Response
{
    public class CheckTokenResponse
    {
        public string NamaPengguna { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiredToken { get; set; }
    }
}
