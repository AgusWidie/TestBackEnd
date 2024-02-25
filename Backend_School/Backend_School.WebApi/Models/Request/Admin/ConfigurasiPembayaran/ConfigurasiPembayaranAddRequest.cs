using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class ConfigurasiPembayaranAddRequest
    {
        public string NamaPembayaran { get; set; }
        public long IdTahunAjaran { get; set; }
        public int Kelas { get; set; }
        public long NilaiPembayaran { get; set; }
        public bool? Aktif { get; set; }
        public string Deskripsi { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
    }
}
