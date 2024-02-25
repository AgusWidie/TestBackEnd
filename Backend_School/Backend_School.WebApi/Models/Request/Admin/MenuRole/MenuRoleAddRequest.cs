using System;

namespace Backend_School.WebApi.Models.Request
{
    public class MenuRoleAddRequest
    {
        public long IdRole { get; set; }
        public long IdMenu { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
