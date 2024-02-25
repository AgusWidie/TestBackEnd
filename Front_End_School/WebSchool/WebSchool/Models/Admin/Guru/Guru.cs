using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class Guru
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("nomorIndukPegawai")]
        public string NomorIndukPegawai { get; set; }
        [JsonPropertyName("noKtp")]
        public string NoKTP { get; set; }
        [JsonPropertyName("namaGuru")]
        public string NamaGuru { get; set; }
        [JsonPropertyName("jenisKelamin")]
        public string JenisKelamin { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("statusGuru")]
        public string StatusGuru { get; set; }
        [JsonPropertyName("agama")]
        public string Agama { get; set; }
        [JsonPropertyName("alamat")]
        public string Alamat { get; set; }
        [JsonPropertyName("pendidikan")]
        public string Pendidikan { get; set; }
        [JsonPropertyName("tanggalLahir")]
        public DateTime? TanggalLahir { get; set; }
        [JsonPropertyName("noHp")]
        public string NoHp { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("filePhoto")]
        public string FilePhoto { get; set; }
        [JsonPropertyName("penggunaBuat")]
        public string PenggunaBuat { get; set; }
        [JsonPropertyName("terminalBuat")]
        public string TerminalBuat { get; set; }
        [JsonPropertyName("tanggalBuat")]
        public DateTime? TanggalBuat { get; set; }
        [JsonPropertyName("penggunaPerbarui")]
        public string PenggunaPerbarui { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
        [JsonPropertyName("tanggalPerbarui")]
        public DateTime? TanggalPerbarui { get; set; }
    }
}
