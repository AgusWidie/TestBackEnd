using System;

namespace Backend_School.WebApi.Models.Response
{
    public class SiswaResponse
    {
        public long Id { get; set; }
        public string NomorIndukSiswa { get; set; }
        public string NamaSiswa { get; set; }
        public string JenisKelamin { get; set; }
        public string Alamat { get; set; }
        public string Agama { get; set; }
        public DateTime? TanggalLahir { get; set; }
        public string NoHp { get; set; }
        public long IdKelas { get; set; }
        public string NamaKelas { get; set; }
        public long IdTahunAjaran { get; set; }
        public string TahunAjaran { get; set; }
        public string Email { get; set; }
        public string StatusSiswa { get; set; }
        public string NamaAyah { get; set; }
        public string NamaIbu { get; set; }
        public string AlamatOrangTua { get; set; }
        public string NoHpOrangTua { get; set; }
        public string PekerjaanOrangTua { get; set; }
        public long PenghasilanOrangTua { get; set; }
        public bool? Aktif { get; set; }
        public string FilePhoto { get; set; }
        public string PenggunaBuat { get; set; }
        public string TerminalBuat { get; set; }
        public DateTime? TanggalBuat { get; set; }
        public string PenggunaPerbarui { get; set; }
        public string TerminalPerbarui { get; set; }
        public DateTime? TanggalPerbarui { get; set; }
    }
}

