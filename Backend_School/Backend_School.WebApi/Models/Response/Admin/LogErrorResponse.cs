using System;

namespace Backend_School.WebApi.Models.Response
{
    public class LogErrorResponse
    {
        public long Id { get; set; }
        public string NamaService { get; set; }
        public string NamaAction { get; set; }
        public string ErrorDeskripsi { get; set; }
        public DateTime? TanggalError { get; set; }
    }
}
