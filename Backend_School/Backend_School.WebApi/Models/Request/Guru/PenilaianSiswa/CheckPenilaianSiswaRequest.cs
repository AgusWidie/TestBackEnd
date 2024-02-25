using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckPenilaianSiswaRequest
    {
        public long IdSiswa { get; set; }
        public long IdKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public long IdPenilaian { get; set; }
    }
}
