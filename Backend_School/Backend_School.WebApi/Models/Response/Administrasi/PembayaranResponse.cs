
using System;

namespace Backend_School.WebApi.Models.Response
{
    public class PembayaranResponse
    {
        public long Id { get; set; }
        public long IdSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public long IdConfigPembayaran { get; set; }
        public string NamaPembayaran { get; set; }
        public long NilaiPembayaran { get; set; }
        public string TahunAjaran { get; set; }
        public long Bayar { get; set; }
        public long Kembalian { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
