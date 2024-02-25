using System;

namespace Backend_School.WebApi.Models.Request
{
    public class MenuRoleUpdateRequest
    {
        public long Id { get; set; }
        public long IdRole { get; set; }
        public long IdMenu { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}
