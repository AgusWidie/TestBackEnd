using System;

namespace Backend_School.WebApi.Models.Response
{
    public class SPPResponse
    {
        public long Id { get; set; }
        public long IdSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public long IdKelas { get; set; }
        public string NamaKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public string TahunAjaran { get; set; }
        public Int32 Tahun { get; set; }
        public Int32 Bulan { get; set; }
        public string NamaBulan { get; set; }
        public long NilaiSPP { get; set; }
        public long Bayar { get; set; }
        public long Kembalian { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }

    public class BulanResponse
    {
        public long Id { get; set; }
        public int Bulan { get; set; }
        public string NamaBulan { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
