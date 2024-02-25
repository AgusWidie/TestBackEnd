using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckDaftarUlangRequest
    {
        public long IdSiswa { get; set; }
        public long IdTahunAjaran { get; set; }
        public long KelasTahunAjaran { get; set; }
        public long IdTahunAjaranTo { get; set; }
        public long KelasTahunAjaranTo { get; set; }
    }
}
