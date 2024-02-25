using System;

namespace Backend_School.WebApi.Models.Request
{
    public class GuruUpdatePhotoRequest
    {
        public string NomorIndukPegawai { get; set; }
        public string NamaGuru { get; set; }
        public string FilePhoto { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
