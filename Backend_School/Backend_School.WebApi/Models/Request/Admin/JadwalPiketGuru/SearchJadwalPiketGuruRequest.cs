namespace Backend_School.WebApi.Models.Request
{
    public class SearchJadwalPiketGuruRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdGuru { get; set; }
        public string Hari { get; set; }
    }
}
