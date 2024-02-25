using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class AbsenGuruAddRequest
    {
        public long IdGuru { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public string NamaAbsen { get; set; }
        public DateTime? AbsenMasuk { get; set; }
        public DateTime? AbsenKeluar { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
