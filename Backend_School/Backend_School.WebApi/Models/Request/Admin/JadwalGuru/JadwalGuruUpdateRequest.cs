using System;

namespace Backend_School.WebApi.Models.Request
{
    public class JadwalGuruUpdateRequest
    {
        public long Id { get; set; }
        public long IdGuru { get; set; }
        public string Hari { get; set; }
        public long IdKelas { get; set; }
        public long IdPelajaran { get; set; }
        public long IdTahunAjaran { get; set; }
        public TimeSpan? DariJam { get; set; }
        public TimeSpan? SampaiJam { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
