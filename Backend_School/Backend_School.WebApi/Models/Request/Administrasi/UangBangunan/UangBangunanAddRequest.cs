using System;

namespace Backend_School.WebApi.Models.Request
{
    public class UangBangunanAddRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public long IdSiswa { get; set; }
        public DateTime? Tanggal { get; set; }
        public string NamaPembayaran { get; set; }
        public long NilaiUangBangunan { get; set; }
        public long Bayar { get; set; }
        public long TotalBayar { get; set; }
        public long SisaBayar { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
