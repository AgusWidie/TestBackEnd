using System;

namespace Backend_School.WebApi.Models.Request
{
    public class SPPUpdateRequest
    {
        public long Id { get; set; }
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public Int32 Tahun { get; set; }
        public Int32 Bulan { get; set; }
        public string NamaBulan { get; set; }
        public string NamaPembayaran { get; set; }
        public long NilaiSPP { get; set; }
        public long Bayar { get; set; }
        public long Kembalian { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
