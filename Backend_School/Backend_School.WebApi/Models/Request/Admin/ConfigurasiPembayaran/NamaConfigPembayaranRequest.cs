namespace Backend_School.WebApi.Models.Request
{
    public class NamaConfigPembayaranRequest
    {
        public string NamaPembayaran { get; set; }
        public int Kelas { get; set; }
        public long IdTahunAjaran { get; set; }
    }
}
