using System;

namespace Backend_School.WebApi.Models.Request
{
    public class PenggunaAddRequest
    {
        public string NamaPengguna { get; set; }
        public long IdGuru { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public DateTime? ExpiredPassword { get; set; }
        public bool? Aktif { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
