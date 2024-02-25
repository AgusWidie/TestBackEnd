using System;

namespace Backend_School.WebApi.Models.Request
{
    public class SiswaUpdatePhotoRequest
    {
        public string NomorIndukSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public string FilePhoto { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
