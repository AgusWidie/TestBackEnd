using System;

namespace Backend_School.WebApi.Models.Request
{
    public class PenilaianSiswaUpdateRequest
    {
        public long Id { get; set; }
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public long IdPenilaian { get; set; }
        public decimal? Nilai { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
