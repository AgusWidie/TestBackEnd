using System;

namespace Backend_School.WebApi.Models.Request
{
    public class GuruAddPhotoRequest
    {
        public string NomorIndukPegawai { get; set; }
        public string NamaGuru { get; set; }
        public string FilePhoto { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
