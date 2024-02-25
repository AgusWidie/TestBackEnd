using System;

namespace Backend_School.WebApi.Models.Response
{
    public class PenggunaResponse
    {
        public long Id { get; set; }
        public string NamaPengguna { get; set; }
        public long IdGuru { get; set; }
        public string NamaGuru { get; set; }
        public string Email { get; set; }
        public string StatusPengguna { get; set; }
        public DateTime? ExpiredPassword { get; set; }
        public string Deskripsi { get; set; }
        public bool? Aktif { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
