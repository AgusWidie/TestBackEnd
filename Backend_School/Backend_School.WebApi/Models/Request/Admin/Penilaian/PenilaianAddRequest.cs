using System;

namespace Backend_School.WebApi.Models.Request
{
    public class PenilaianAddRequest
    {
        public long IdPelajaran { get; set; }
        public string NamaPenilaian { get; set; }
        public string Deskripsi { get; set; }
        public bool? Aktif { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
