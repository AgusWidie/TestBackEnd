using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckSPPRequest
    {
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public Int32 Tahun { get; set; }
        public Int32 Bulan { get; set; }
    }
}
