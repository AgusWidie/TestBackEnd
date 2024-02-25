using System;
using System.ComponentModel.DataAnnotations;

namespace Backend_School.WebApi.Models.Request
{
    public class CheckTokenRequest
    {
        public string ApiKey { get; set; }
        public string NamaPengguna { get; set; }
    }
}
