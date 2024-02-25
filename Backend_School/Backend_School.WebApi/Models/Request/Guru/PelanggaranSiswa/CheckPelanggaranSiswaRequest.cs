using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckPelanggaranSiswaRequest
    {
        public long IdSiswa { get; set; }
        public long IdPelanggaran { get; set; }
    }
}
