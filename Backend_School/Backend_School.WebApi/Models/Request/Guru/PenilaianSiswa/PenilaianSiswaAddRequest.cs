using System;

namespace Backend_School.WebApi.Models.Request
{
    public class PenilaianSiswaAddRequest
    {
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public long IdPenilaian { get; set; }
        public decimal? Nilai { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
