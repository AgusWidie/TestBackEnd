using System;

namespace Backend_School.WebApi.Models.Request
{
    public class TokenRequest
    {
        public string NamaPengguna { get; set; }
        public long IdGuru { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiredDate { get; set; }
    }
}
