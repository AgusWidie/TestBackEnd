using System;

namespace Backend_School.WebApi.Models.Request
{
    public class RaportSiswaUpdateRequest
    {
        public long Id { get; set; }
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdPelajaran { get; set; }
        public long IdTahunAjaran { get; set; }
        public decimal? Nilai { get; set; }
        public string Keterangan { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
