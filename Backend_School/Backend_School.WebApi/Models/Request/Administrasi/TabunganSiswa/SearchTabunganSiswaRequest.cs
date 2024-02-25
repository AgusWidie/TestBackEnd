namespace Backend_School.WebApi.Models.Request
{
    public class SearchTabunganSiswaRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
    }
}
