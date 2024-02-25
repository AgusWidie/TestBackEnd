using System;

namespace Backend_School.WebApi.Models.Request
{
    public class SPPAddRequest
    {
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public Int32 Tahun { get; set; }
        public Int32 Bulan { get; set; }
        public string NamaBulan { get; set; }
        public string NamaPembayaran { get; set; }
        public long NilaiSPP { get; set; }
        public long Bayar { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
