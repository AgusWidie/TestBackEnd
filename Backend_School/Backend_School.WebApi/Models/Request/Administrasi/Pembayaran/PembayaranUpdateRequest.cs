
using System;

namespace Backend_School.WebApi.Models.Request
{
    public class PembayaranUpdateRequest
    {
        public long Id { get; set; }
        public long IdSiswa { get; set; }
        public long IdConfigPembayaran { get; set; }
        public long NilaiPembayaran { get; set; }
        public long Bayar { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
