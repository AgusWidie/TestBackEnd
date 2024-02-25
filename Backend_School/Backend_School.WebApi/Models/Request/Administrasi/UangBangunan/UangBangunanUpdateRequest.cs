using System;

namespace Backend_School.WebApi.Models.Request
{
    public class UangBangunanUpdateRequest
    {
        public long Id { get; set; }
        public long IdTahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public long IdSiswa { get; set; }
        public DateTime? Tanggal { get; set; }
        public string NamaPembayaran { get; set; }
        public long NilaiUangBangunan { get; set; }
        public long Bayar { get; set; }
        public long TotalBayar { get; set; }
        public long SisaBayar { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
