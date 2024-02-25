using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckConfigurasiPembayaranRequest
    {
        public string NamaPembayaran { get; set; }
        public long IdTahunAjaran { get; set; }
    }
}
