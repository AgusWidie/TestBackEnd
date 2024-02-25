using System.Text.Json.Serialization;

namespace WebSchool.Models.Admin.DataConfigPembayaran
{
    public class NamaConfigPembayaran
    {
        [JsonPropertyName("namaPembayaran")]
        public string NamaPembayaran { get; set; }
        [JsonPropertyName("kelas")]
        public int Kelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
    }
}
