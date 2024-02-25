using System;

namespace Backend_School.WebApi.Models.Request
{
    public class MenuUpdateRequest
    {
        public long Id { get; set; }
        public long IdMenuParent { get; set; }
        public string NamaMenu { get; set; }
        public string NamaController { get; set; }
        public string NamaAction { get; set; }
        public Int32 Sort { get; set; }
        public bool? Aktif { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
