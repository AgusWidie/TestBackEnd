namespace Backend_School.WebApi.Models.Request
{
    public class CheckRaportSiswaRequest
    {
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdPelajaran { get; set; }
        public long IdTahunAjaran { get; set; }
    }
}
