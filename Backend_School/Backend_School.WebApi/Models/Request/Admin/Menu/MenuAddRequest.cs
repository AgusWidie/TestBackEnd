using System;

namespace Backend_School.WebApi.Models.Request
{
    public class MenuAddRequest
    {
        public string NamaMenu { get; set; }
        public string NamaController { get; set; }
        public string NamaAction { get; set; }
        public Int32 Sort { get; set; }
        public bool? Aktif { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
