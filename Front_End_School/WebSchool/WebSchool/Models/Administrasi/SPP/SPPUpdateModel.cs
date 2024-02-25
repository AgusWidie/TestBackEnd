using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SPPUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("idSiswa")]
        public long IdSiswa { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("tahun")]
        public Int32 Tahun { get; set; }
        [JsonPropertyName("bulan")]
        public Int32 Bulan { get; set; }
        [JsonPropertyName("namaBulan")]
        public string NamaBulan { get; set; }
        [JsonPropertyName("namaPembayaran")]
        public long NamaPembayaran { get; set; }
        [JsonPropertyName("nilaiSpp")]
        public long NilaiSPP { get; set; }
        [JsonPropertyName("bayar")]
        public long Bayar { get; set; }
        [JsonPropertyName("kembalian")]
        public long Kembalian { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
