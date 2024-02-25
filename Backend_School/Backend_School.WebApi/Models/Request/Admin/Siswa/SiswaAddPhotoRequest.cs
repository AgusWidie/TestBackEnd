using System;

namespace Backend_School.WebApi.Models.Request
{
    public class SiswaAddPhotoRequest
    {
        public string NomorIndukSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public string FilePhoto { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
