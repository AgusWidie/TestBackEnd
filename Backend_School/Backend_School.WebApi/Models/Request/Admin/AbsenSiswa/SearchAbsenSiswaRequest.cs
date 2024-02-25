using System;

namespace Backend_School.WebApi.Models.Request
{
    public class SearchAbsenSiswaRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public DateTime? TanggalAbsen { get; set; }

    }
}
