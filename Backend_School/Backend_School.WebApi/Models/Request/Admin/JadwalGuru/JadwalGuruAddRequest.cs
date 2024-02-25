using System;

namespace Backend_School.WebApi.Models.Request
{
    public class JadwalGuruAddRequest
    {
        public long IdGuru { get; set; }
        public string Hari { get; set; }
        public long IdTahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public long IdPelajaran { get; set; }
        public TimeSpan? DariJam { get; set; }
        public TimeSpan? SampaiJam { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
