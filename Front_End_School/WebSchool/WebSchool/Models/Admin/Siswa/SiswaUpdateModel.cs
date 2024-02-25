using System;
using System.Text.Json.Serialization;

namespace WebSchool.Models
{
    public class SiswaUpdateModel
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }
        [JsonPropertyName("nomorIndukSiswa")]
        public string NomorIndukSiswa { get; set; }
        [JsonPropertyName("namaSiswa")]
        public string NamaSiswa { get; set; }
        [JsonPropertyName("jenisKelamin")]
        public string JenisKelamin { get; set; }
        [JsonPropertyName("alamat")]
        public string Alamat { get; set; }
        [JsonPropertyName("agama")]
        public string Agama { get; set; }
        [JsonPropertyName("tanggalLahir")]
        public DateTime? TanggalLahir { get; set; }
        [JsonPropertyName("noHp")]
        public string NoHp { get; set; }
        [JsonPropertyName("idKelas")]
        public long IdKelas { get; set; }
        [JsonPropertyName("idTahunAjaran")]
        public long IdTahunAjaran { get; set; }
        [JsonPropertyName("email")]
        public string Email { get; set; }
        [JsonPropertyName("statusSiswa")]
        public string StatusSiswa { get; set; }
        [JsonPropertyName("namaAyah")]
        public string NamaAyah { get; set; }
        [JsonPropertyName("namaIbu")]
        public string NamaIbu { get; set; }
        [JsonPropertyName("alamatOrangTua")]
        public string AlamatOrangTua { get; set; }
        [JsonPropertyName("noHpOrangTua")]
        public string NoHpOrangTua { get; set; }
        [JsonPropertyName("pekerjaanOrangTua")]
        public string PekerjaanOrangTua { get; set; }
        [JsonPropertyName("penghasilanOrangTua")]
        public long PenghasilanOrangTua { get; set; }
        [JsonPropertyName("aktif")]
        public bool? Aktif { get; set; }
        [JsonPropertyName("filePhoto")]
        public string FilePhoto { get; set; }
        [JsonPropertyName("terminalPerbarui")]
        public string TerminalPerbarui { get; set; }
    }
}
