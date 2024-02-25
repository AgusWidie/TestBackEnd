using System;

namespace Backend_School.WebApi.Models.Request
{
    public class JadwalPiketGuruUpdateRequest
    {

        public long Id { get; set; }
        public long IdTahunAjaran { get; set; }
        public long IdGuru { get; set; }
        public string Hari { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
