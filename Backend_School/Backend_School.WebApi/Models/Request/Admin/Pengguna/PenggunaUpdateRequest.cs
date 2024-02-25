using System;

namespace Backend_School.WebApi.Models.Request
{
    public class PenggunaUpdateRequest
    {
        public long Id { get; set; }
        public string NamaPengguna { get; set; }
        public long IdGuru { get; set; }
        public string Pass { get; set; }
        public string Email { get; set; }
        public DateTime? ExpiredPassword { get; set; }
        public bool? Aktif { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
