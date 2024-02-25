using System;

namespace Backend_School.WebApi.Models.Request
{
    public class SearchPembayaranRequest
    {
        public long IdTahunAjaran { get; set; }
        public Int32 Kelas { get; set; }
        public long IdSiswa { get; set; }
    }
}
