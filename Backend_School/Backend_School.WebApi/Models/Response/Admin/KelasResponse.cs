using System;

namespace Backend_School.WebApi.Models.Response
{
    public class KelasResponse
    {
        public long Id { get; set; }
        public Int32 Kelas { get; set; }
        public string NamaKelas { get; set; }
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
