using System;

namespace Backend_School.WebApi.Models.Request
{
    public class TabunganSiswaAddRequest
    {
        public long IdTahunAjaran { get; set; }
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long Debit { get; set; }
        public long Credit { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
