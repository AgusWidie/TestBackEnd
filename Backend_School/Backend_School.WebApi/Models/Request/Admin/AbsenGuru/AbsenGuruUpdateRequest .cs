using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class AbsenGuruUpdateRequest
    {
        public long Id { get; set; }
        public long IdGuru { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public string NamaAbsen { get; set; }
        public DateTime? AbsenKeluar { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
