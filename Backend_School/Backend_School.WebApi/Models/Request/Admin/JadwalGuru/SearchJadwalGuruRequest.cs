namespace Backend_School.WebApi.Models.Request
{
    public class SearchJadwalGuruRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdKelas { get; set; }
        public long IdPelajaran { get; set; }
    }
}
