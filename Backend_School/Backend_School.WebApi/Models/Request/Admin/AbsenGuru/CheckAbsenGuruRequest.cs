using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckAbsenGuruRequest
    {
        public long IdGuru { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public DateTime? TanggalAbsen { get; set; }
    }
}
