using System;

namespace Backend_School.WebApi.Models.Response
{
    public class MenuRoleResponse
    {
        public long Id { get; set; }
        public long IdRole { get; set; }
        public string NamaRole { get; set; }
        public long IdMenu { get; set; }
        public string NamaMenu { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
