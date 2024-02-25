using System;

namespace Backend_School.WebApi.Models.Request
{
    public class SearchAbsenGuruRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public DateTime? AbsenMasuk { get; set; }
    }
}
