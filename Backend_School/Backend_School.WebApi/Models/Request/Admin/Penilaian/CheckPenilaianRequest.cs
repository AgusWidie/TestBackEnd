using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckPenilaianRequest
    {
        public long IdPelajaran { get; set; }
        public string NamaPenilaian { get; set; }
    }
}
