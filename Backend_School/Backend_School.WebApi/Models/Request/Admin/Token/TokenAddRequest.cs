using System;

namespace Backend_School.WebApi.Models.Request
{
    public class TokenAddRequest
    {
        public string NamaPengguna { get; set; }
        public string NamaRole { get; set; }
        public string NamaGuru { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public DateTime? ExpiredToken { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
