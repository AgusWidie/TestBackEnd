using System;

namespace Backend_School.WebApi.Models.Response
{
    public class MenuResponse
    {
        public long Id { get; set; }
        public long IdMenuParent { get; set; }
        public long IdMenu { get; set; }
        public string NamaMenuParent { get; set; }
        public string NamaMenu { get; set; }
        public string NamaController { get; set; }
        public string NamaAction { get; set; }
        public string Type { get; set; }
        public Int32 Sort { get; set; }
        public bool? Aktif { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
