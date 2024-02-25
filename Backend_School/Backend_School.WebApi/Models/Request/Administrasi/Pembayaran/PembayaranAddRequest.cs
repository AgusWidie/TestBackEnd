
using System;

namespace Backend_School.WebApi.Models.Request
{
    public class PembayaranAddRequest
    {
        public long IdSiswa { get; set; }
        public long IdConfigPembayaran { get; set; }
        public long NilaiPembayaran { get; set; }
        public long Bayar { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
