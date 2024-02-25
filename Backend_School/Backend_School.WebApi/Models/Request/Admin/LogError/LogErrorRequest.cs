using System;

namespace Backend_School.WebApi.Models.Request
{
    public class LogErrorRequest
    {
        public string NamaService { get; set; }
        public string NamaAction { get; set; }
        public string ErrorDeskripsi { get; set; }
        public DateTime? TanggalError { get; set; }
    }
}
