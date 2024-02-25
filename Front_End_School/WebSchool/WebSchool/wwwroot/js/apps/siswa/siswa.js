var base64String;
var IdTahunAjaran;
var IdKelas;

function SaveDataSiswa() {

    try {
        var NamaSiswa = document.getElementById("NamaSiswa").value;
        var JenisKelamin = document.getElementById("JenisKelamin").value;
        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var Email = document.getElementById("Email").value;
        var Status = document.getElementById("StatusSiswa").value;
        var Agama = document.getElementById("Agama").value;
        var Alamat = document.getElementById("Alamat").value;
        var NoHP = document.getElementById("NoHP").value;
        var TanggalLahir = document.getElementById("TanggalLahir").value;
        var NamaAyah = document.getElementById("NamaAyah").value;
        var NamaIbu = document.getElementById("NamaIbu").value;
        var NoHpOrangTua = document.getElementById("NoHpOrangTua").value;
        var PekerjaanOrangTua = document.getElementById("PekerjaanOrangTua").value;
        var PenghasilanOrangTua = document.getElementById("PenghasilanOrangTua").value;
        var Aktif = document.getElementById("Aktif").value;
        var FilePhoto = base64String;
        var bolAktif = false;

        var number = /^[0-9]+$/;
        var validRegexEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

        if (NamaSiswa == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Siswa Kosong..!'
            })
            return;
        }

        if (JenisKelamin == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Jenis Kelamin Kosong..!'
            })
            return;
        }

        if (JenisKelamin != "Laki-Laki" && JenisKelamin != "Perempuan") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Jenis Kelamin tidak valid..! --> ' + JenisKelamin
            })
            return;
        }

        if (IdTahunAjaran == "" || IdTahunAjaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Tahun Ajaran Kosong..!'
            })
            return;
        }

        if (IdKelas == "" || IdKelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kelas Kosong..!'
            })
            return;
        }

        if (Status == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Kosong..!'
            })
            return;
        }

        if (Status !== "Siswa Baru") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Siswa tidak valid..!, status siswa --> ' + Status
            })
            return;
        }

        if (Agama == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Agama Kosong..!'
            })
            return;
        }

        if (Agama != "Islam" && Agama != "Kristen" && Agama != "Hindu" && Agama != "Budha" && Agama != "Konghucu") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Agama tidak valid..!, Agama --> ' + Agama
            })
            return;
        }

        if (Email !== "") {

            if (!Email.value.match(validRegexEmail)) {
                Swal.fire({
                    title: 'Informasi..!',
                    text: 'Email tidak valid..!'
                })
                return;
            }
        }

        if (Alamat == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Alamat Kosong..!'
            })
            return;
        }

        if (NamaAyah == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Ayah Kosong..!'
            })
            return;
        }

        if (NamaIbu == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Ibu Kosong..!'
            })
            return;
        }

        if (NoHpOrangTua == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No Hp Orang Tua Kosong..!'
            })
            return;
        }

        if (!NoHpOrangTua.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No HP Orang Tua tidak mengandung karakter angka.'
            })
            return;
        }

        if (PekerjaanOrangTua == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Pekerjaan Orang Tua Kosong..!'
            })
            return;
        }

        if (PenghasilanOrangTua == "" || PenghasilanOrangTua == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Penghasilan Orang Tua Kosong..!'
            })
            return;
        }


        if (!PenghasilanOrangTua.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Penghasilan Orang Tua tidak mengandung angka..!'
            })
            return;
        }

        if (Aktif == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Aktif Kosong..!'
            })
            return;
        }

        if (Aktif != "0" && Aktif != "1") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Check nilai Aktif --> ' + Aktif
            })
            return;
        }

        if (Aktif == "1") {

            bolAktif = true;

        } else {

            bolAktif = false;

        }

        var data = { namaSiswa: NamaSiswa, jenisKelamin: JenisKelamin, idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), email: Email, statusSiswa: Status, agama: Agama, alamat: Alamat, noHp: NoHP, tanggalLahir: TanggalLahir, namaAyah: NamaAyah, namaIbu: NamaIbu, noHpOrangTua: NoHpOrangTua, pekerjaanOrangTua: PekerjaanOrangTua, penghasilanOrangTua: parseInt(PenghasilanOrangTua), aktif: bolAktif, filePhoto: FilePhoto };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Siswa/AddSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Siswa Berhasil Disimpan..!'
                    })
                    $('#TambahSiswa').modal('hide');
                    GetDataSiswa();
                    return;
                }
                else {
                    Swal.fire({
                        title: 'Informasi..!',
                        text: '' + data.message + ''
                    })
                    return;
                }
            },
            error: function (error) {

            }
        });
    }
    catch (err) {
        alert(err.toString());
    }
    
}

function UpdateDataSiswa() {

    try {
        var Id = document.getElementById("Id").value;
        var NamaSiswa = document.getElementById("NamaSiswa1").value;
        var JenisKelamin = document.getElementById("JenisKelamin1").value;
        var IdTahunAjaran = document.getElementById("TahunAjaran1").value;
        var IdKelas = document.getElementById("NamaKelas1").value;
        var Email = document.getElementById("Email1").value;
        var Status = document.getElementById("StatusSiswa1").value;
        var Agama = document.getElementById("Agama1").value;
        var Alamat = document.getElementById("Alamat1").value;
        var Pendidikan = document.getElementById("Pendidikan1").value;
        var TanggalLahir = document.getElementById("TanggalLahir1").value;
        var NamaAyah = document.getElementById("NamaAyah1").value;
        var NamaIbu = document.getElementById("NamaIbu1").value;
        var NoHpOrangTua = document.getElementById("NoHpOrangTua1").value;
        var PekerjaanOrangTua = document.getElementById("PekerjaanOrangTua1").value;
        var PenghasilanOrangTua = document.getElementById("PenghasilanOrangTua1").value;
        var Aktif = document.getElementById("Aktif").value;
        var FilePhoto = base64String;
        var bolAktif = false;

        var number = /^[0-9]+$/;
        var validRegexEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

        if (Id == "" || Id == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kosong..!'
            })
            return;
        }

        if (NamaSiswa == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Siswa Kosong..!'
            })
            return;
        }

        if (JenisKelamin == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Jenis Kelamin Kosong..!'
            })
            return;
        }

        if (JenisKelamin != "Laki-Laki" && JenisKelamin != "Perempuan") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Jenis Kelamin tidak valid..! --> ' + JenisKelamin
            })
            return;
        }

        if (IdTahunAjaran == "" || IdTahunAjaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Tahun Ajaran Kosong..!'
            })
            return;
        }

        if (IdKelas == "" || IdKelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kelas Kosong..!'
            })
            return;
        }

        if (Status == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Kosong..!'
            })
            return;
        }

        if (Status !== "Siswa Lama" && Status !== "Siswa Pindah" && Status !== "Siswa Lulus") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status SIswa tidak valid..!, status siswa --> ' + Status
            })
            return;
        }

        if (Agama == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Agama Kosong..!'
            })
            return;
        }

        if (Agama != "Islam" && Agama != "Kristen" && Agama != "Hindu" && Agama != "Budha" && Agama != "Konghucu") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Agama tidak valid..!, Agama --> ' + Agama
            })
            return;
        }

        if (Email !== "") {

            if (!Email.value.match(validRegexEmail)) {
                Swal.fire({
                    title: 'Informasi..!',
                    text: 'Email tidak valid..!'
                })
                return;
            }
        }

        if (Alamat == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Alamat Kosong..!'
            })
            return;
        }

        if (NamaAyah == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Ayah Kosong..!'
            })
            return;
        }

        if (NamaIbu == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Ibu Kosong..!'
            })
            return;
        }

        if (NoHpOrangTua == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No Hp Orang Tua Kosong..!'
            })
            return;
        }

        if (!NoHpOrangTua.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No HP Orang Tua tidak mengandung karakter angka.'
            })
            return;
        }

        if (PekerjaanOrangTua == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Pekerjaan Orang Tua Kosong..!'
            })
            return;
        }

        if (PenghasilanOrangTua == "" || PenghasilanOrangTua == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Penghasilan Orang Tua Kosong..!'
            })
            return;
        }


        if (!PenghasilanOrangTua.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Penghasilan Orang Tua tidak mengandung angka..!'
            })
            return;
        }

        if (Aktif == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Aktif Kosong..!'
            })
            return;
        }

        if (Aktif != "0" && Aktif != "1") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Check nilai Aktif --> ' + Aktif
            })
            return;
        }

        if (Aktif == "1") {

            bolAktif = true;

        } else {

            bolAktif = false;

        }

        var data = { id: parseInt(Id), namaSiswa: NamaSiswa, jenisKelamin: JenisKelamin, idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), email: Email, statusSiswa: Status, agama: Agama, alamat: Alamat, pendidikan: Pendidikan, tanggalLahir: TanggalLahir, namaAyah: NamaAyah, namaIbu: NamaIbu, noHpOrangTua: NoHpOrangTua, pekerjaanOrangTua: PekerjaanOrangTua, penghasilanOrangTua: parseInt(PenghasilanOrangTua), aktif: bolAktif, filePhoto: FilePhoto };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Siswa/UpdateSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            cache: false,
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Siswa Berhasil Disimpan..!'
                    })
                    $('#EditSiswa').modal('hide');
                    GetDataSiswa();
                    return;
                }
                else {
                    Swal.fire({
                        title: 'Informasi..!',
                        text: '' + data.message + ''
                    })
                    return;
                }
            },
            error: function (error) {

            }
        });
    }
    catch (err) {
        alert(err.toString());
    }
    
}

function GetDataSiswa() {

    try {

        IdTahunAjaran = document.getElementById("TahunAjaran2").value;
        IdKelas = document.getElementById("NamaKelas2").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == null) {
            IdTahunAjaran = "0";
        }

        if (IdKelas == "" || IdKelas == null) {
            IdKelas = "0";
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas) };
        var stringData = JSON.stringify(data);

        $("#tabelSiswa").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Siswa/SiswaSearch",
                "type": "POST",
                "contentType": "application/json; charset=utf-8",
                "datatype": "json",
                "data": "" + stringData + ""
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'nomorIndukSiswa', "autoWidth": true },
                { 'data': 'namaSiswa', "autoWidth": true },
                { 'data': 'jenisKelamin', "autoWidth": true },
                { 'data': 'tahunAJaran', "autoWidth": true },
                { 'data': 'namaKelas', "autoWidth": true },
                { 'data': 'noHp', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editSiswa(\'' + row.id + '\',\'' + row.namaSiswa + '\',\'' + row.jenisKelamin + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.email + '\',\'' + row.statusSiswa + '\',\'' + row.agama + '\',\'' + row.alamat + '\',\'' + row.tanggalLahir + '\',\'' + row.noHp + '\',\'' + row.namaAyah + '\',\'' + row.namaIbu + '\',\'' + row.noHpOrangTua + '\',\'' + row.pekerjaanOrangTua + '\',\'' + row.penghasilanOrangTua + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function imageData() {
    var file = document.querySelector(
        'input[type=file]')['files'][0];

    var reader = new FileReader();
    console.log("next");

    reader.onload = function () {
        //base64String = reader.result.replace("data:", "").replace(/^.+,/, "");
        base64String = reader.result;

        imageBase64Stringsep = base64String;
        //console.log(base64String);
    }
    reader.readAsDataURL(file);
}