using System;

namespace Backend_School.WebApi.Models.Response
{
    public class JadwalGuruResponse
    {
        public long Id { get; set; }
        public long IdGuru { get; set; }
        public string NamaGuru { get; set; }
        public string Hari { get; set; }
        public long IdKelas { get; set; }
        public string NamaKelas { get; set; }
        public long IdPelajaran { get; set; }
        public string NamaPelajaran { get; set; }
        public long IdTahunAjaran { get; set; }
        public string TahunAjaran { get; set; }
        public TimeSpan? DariJam { get; set; }
        public TimeSpan? SampaiJam { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
