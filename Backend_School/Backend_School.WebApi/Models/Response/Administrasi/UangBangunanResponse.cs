using System;

namespace Backend_School.WebApi.Models.Response
{
    public class UangBangunanResponse
    {
        public long Id { get; set; }
        public long IdTahunAjaran { get; set; }
        public long TahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public long NamaKelas { get; set; }
        public long IdSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public DateTime? Tanggal { get; set; }
        public long NilaiUangBangunan { get; set; }
        public long Bayar { get; set; }
        public long TotalBayar { get; set; }
        public long SisaBayar { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
