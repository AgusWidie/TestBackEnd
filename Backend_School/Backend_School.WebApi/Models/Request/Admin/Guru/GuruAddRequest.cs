using System;

namespace Backend_School.WebApi.Models.Request
{
    public class GuruAddRequest
    {
        public string NomorIndukPegawai { get; set; }
        public string NoKTP { get; set; }
        public string NamaGuru { get; set; }
        public string JenisKelamin { get; set; }
        public string Agama { get; set; }
        public string Status { get; set; }
        public string Alamat { get; set; }
        public string Pendidikan { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string NoHp { get; set; }
        public string Email { get; set; }
        public string StatusGuru { get; set; }
        public bool? Aktif { get; set; }
        public string FilePhoto { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
