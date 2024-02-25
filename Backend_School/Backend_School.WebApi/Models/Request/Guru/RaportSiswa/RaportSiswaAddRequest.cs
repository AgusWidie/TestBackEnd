using System;

namespace Backend_School.WebApi.Models.Request
{
    public class RaportSiswaAddRequest
    {
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdPelajaran { get; set; }
        public long IdTahunAjaran { get; set; }
        public decimal? Nilai { get; set; }
        public string Keterangan { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
