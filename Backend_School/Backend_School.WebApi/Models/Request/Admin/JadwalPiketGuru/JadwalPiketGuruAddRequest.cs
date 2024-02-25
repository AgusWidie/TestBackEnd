using System;

namespace Backend_School.WebApi.Models.Request
{
    public class JadwalPiketGuruAddRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdGuru { get; set; }
        public string Hari { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
