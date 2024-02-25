using System;

namespace Backend_School.WebApi.Models.Response
{
    public class PelanggaranSiswaResponse
    {
        public long Id { get; set; }
        public long IdTahunAjaran { get; set; }
        public string TahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public string NamaKelas { get; set; }
        public long IdSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public long IdPelanggaran { get; set; }
        public string NamaPelanggaran { get; set; }
        public long Poin { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
