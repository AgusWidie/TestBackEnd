using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckPembayaranRequest
    {
        public long IdSiswa { get; set; }
        public long IdConfigPembayaran { get; set; }
    }
}
