using System;

namespace Backend_School.WebApi.Models.Response
{
    public class JadwalPiketGuruResponse
    {
        public long Id { get; set; }
        public long IdTahunAjaran { get; set; }
        public string TahunAjaran { get; set; }
        public long IdGuru { get; set; }
        public string NamaGuru { get; set; }
        public string Hari { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
