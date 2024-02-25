namespace Backend_School.WebApi.Models.Request
{
    public class SearchUangBangunanRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public long IdSiswa { get; set; }
    }
}
