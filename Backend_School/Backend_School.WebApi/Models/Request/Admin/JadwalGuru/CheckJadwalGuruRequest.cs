using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckJadwalGuruRequest
    {
        public long IdGuru { get; set; }
        public string Hari { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public TimeSpan? DariJam { get; set; }
        public TimeSpan? SampaiJam { get; set; }
    }
}
