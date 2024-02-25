using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class AbsenSiswaAddRequest
    {
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public string NamaAbsen { get; set; }
        public DateTime? TanggalAbsen { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
