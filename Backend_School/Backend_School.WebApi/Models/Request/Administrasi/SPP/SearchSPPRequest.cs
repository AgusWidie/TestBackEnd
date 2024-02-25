using System;

namespace Backend_School.WebApi.Models.Request
{
    public class SearchSPPRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public Int32 Tahun { get; set; }
        public string NamaBulan { get; set; }
    }
}
