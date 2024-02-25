var Id = 0;
var base64String;

function SaveDataGuru() {

    try {

        var NoKTP = document.getElementById("NoKTP").value;
        var NamaGuru = document.getElementById("NamaGuru").value;
        var JenisKelamin = document.getElementById("JenisKelamin").value;
        var Agama = document.getElementById("Agama").value;
        var Status = document.getElementById("Status").value;
        var Alamat = document.getElementById("Alamat").value;
        var Pendidikan = document.getElementById("Pendidikan").value;
        var TanggalLahir = document.getElementById("TanggalLahir").value;
        var NoHp = document.getElementById("NoHP").value;
        var Email = document.getElementById("Email").value;
        var StatusGuru = document.getElementById("StatusGuru").value;
        var Aktif = document.getElementById("Aktif").value;
        var FilePhoto = base64String;
        var bolAktif = false;


        var number = /^[0-9]+$/;
        var validRegexEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

        if (NoKTP == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No KTP Kosong..!'
            })
            return;
        }

        if (NamaGuru == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Guru Kosong..!'
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


        if (JenisKelamin !== "Laki-Laki" && JenisKelamin !== "Perempuan") {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Jenis Kelamin tidak valid..!, Jenis Kelamin --> ' + JenisKelamin
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

        if (Status == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Kosong..!'
            })
            return;
        }

        if (Status !== "Belum Menikah" && Status !== "Sudah Menikah" && Status !== "Duda" && Status !== "Janda") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status tidak valid..!, status --> ' + Status
            })
            return;
        }

        if (Alamat == "") {
          
            Swal.fire({
                title: 'Informasi..!',
                text: 'Alamat Kosong..!'
            })
            return;
        }

        if (Pendidikan == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Pendidikan Kosong..!'
            })
            return;
        }

        if (Pendidikan !== "S3" && Pendidikan !== "S2" && Pendidikan !== "S1" && Pendidikan !== "D3") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Pendidikan tidak valid..!, pendidikan --> ' + Pendidikan
            })
            return;
        }

        if (NoHp == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No HP Kosong..!'
            })
            return;
        }

        if (!NoHp.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No HP tidak mengandung karakter angka.'
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

        if (StatusGuru == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Guru Kosong..!'
            })
            return;
        }

        if (StatusGuru !== "Pegawai Kontrak" && StatusGuru !== "Pegawai Tetap") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Guru tidak valid..!, Status Guru --->' + StatusGuru
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
                text: 'Aktif tidak valid, AKtif --> ' + Aktif
            })
            return;
        }

        if (Aktif == "1") {

            bolAktif = true;

        } else {

            bolAktif = false;

        }

        var data = { noKtp: NoKTP, namaGuru: NamaGuru, jenisKelamin: JenisKelamin, agama: Agama, status: Status, alamat: Alamat, pendidikan: Pendidikan, tanggalLahir: TanggalLahir, noHp: NoHp, email: Email, statusGuru: StatusGuru, aktif: bolAktif, filePhoto: FilePhoto };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Guru/AddGuru",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {
                   
                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Guru Berhasil Disimpan..!'
                    })
                    $('#TambahGuru').modal('hide');
                    GetDataGuru();
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

function UpdateDataGuru() {

    try {

        var NoIndukPegawai = document.getElementById("NoIndukPegawai").value;
        var NoKTP = document.getElementById("NoKTP1").value;
        var NamaGuru = document.getElementById("NamaGuru1").value;
        var JenisKelamin = document.getElementById("JenisKelamin1").value;
        var Agama = document.getElementById("Agama1").value;
        var Status = document.getElementById("Status1").value;
        var Alamat = document.getElementById("Alamat1").value;
        var Pendidikan = document.getElementById("Pendidikan1").value;
        var TanggalLahir = document.getElementById("TanggalLahir1").value;
        var NoHp = document.getElementById("NoHP1").value;
        var Email = document.getElementById("Email1").value;
        var StatusGuru = document.getElementById("StatusGuru1").value;
        var Aktif = document.getElementById("Aktif1").value;
        var FilePhoto = base64String;
        var bolAktif = false;

        var number = /^[0-9]+$/;
        var validRegexEmail = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

       
        if (NoKTP == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No KTP Kosong..!'
            })
            return;
        }

        if (NamaGuru == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Guru Kosong..!'
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
                text: 'Jenis Kelamin tidak valid..!, Jenis Kelamin --> ' + JenisKelamin
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

        if (Status == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Kosong..!'
            })
            return;
        }

        if (Status !== "Belum Menikah" && Status !== "Sudah Menikah" && Status !== "Duda" && Status !== "Janda") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status tidak valid..!, status --> ' + Status
            })
            return;
        }

        if (Alamat == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Alamat Kosong..!'
            })
            return;
        }

        if (Pendidikan == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Pendidikan Kosong..!'
            })
            return;
        }

        if (Pendidikan !== "S3" && Pendidikan !== "S2" && Pendidikan !== "S1" && Pendidikan !== "D3") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Pendidikan tidak valid..!, pendidikan --> ' + Pendidikan
            })
            return;
        }

        if (NoHp == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No HP Kosong..!'
            })
            return;
        }


        if (!NoHp.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'No HP tidak mengandung karakter angka.'
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

        if (StatusGuru == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Guru Kosong..!'
            })
            return;
        }

        if (StatusGuru !== "Pegawai Kontrak" && StatusGuru !== "Pegawai Tetap") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Guru tidak valid..!, Status Guru --->' + StatusGuru
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
                text: 'Aktif tidak valid, Aktif --> ' + Aktif
            })
            return;
        }


        if (Aktif == "1") {

            bolAktif = true;

        } else {

            bolAktif = false;

        }

        var data = { id: parseInt(Id), noIndukPegawai: NoIndukPegawai, noKtp: NoKTP, namaGuru: NamaGuru, jenisKelamin: JenisKelamin, agama: Agama, status: Status, alamat: Alamat, pendidikan: Pendidikan, tanggalLahir: TanggalLahir, noHp: NoHp, email: Email, statusGuru: StatusGuru, aktif: bolAktif, filePhoto: FilePhoto };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Guru/UpdateGuru",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Guru Berhasil Disimpan..!'
                    })
                    $('#EditGuru').modal('hide');
                    GetDataGuru();
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

function GetDataGuru() {

    try {

        $("#tabelGuru").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Guru/ListGuru?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'noKtp', "autoWidth": true },
                { 'data': 'namaGuru', "autoWidth": true },
                { 'data': 'jenisKelamin', "autoWidth": true },
                { 'data': 'agama', "autoWidth": true },
                { 'data': 'pendidikan', "autoWidth": true },
                { 'data': 'noHp', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editGuru(\'' + row.id + '\',\'' + row.nomorIndukPegawai + '\',\'' + row.noKtp + '\',\'' + row.namaGuru + '\',\'' + row.jenisKelamin + '\',\'' + row.email + '\',\'' + row.statusGuru + '\',\'' + row.agama + '\',\'' + row.alamat + '\',\'' + row.pendidikan + '\',\'' + row.tanggalLahir + '\',\'' + row.noHp + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editGuru(id, nomorIndukPegawai, noKtp, namaGuru, jenisKelamin, email, statusGuru, agama, alamat, pendidikan, tanggalLahir, noHp, aktif) {
    Id = parseInt(id);

    document.getElementById("Id").value = id.toString();
    document.getElementById("NomorIndukPegawai").value = nomorIndukPegawai;
    document.getElementById("NoKTP1").value = noKtp;
    document.getElementById("NamaGuru1").value = namaGuru;
    document.getElementById("JenisKelamin1").value = jenisKelamin;
    document.getElementById("Email1").value = email;
    document.getElementById("StatusGuru1").value = statusGuru;
    document.getElementById("Agama1").value = agama;
    document.getElementById("Alamat1").value = alamat;
    document.getElementById("TanggalLahir1").value = tanggalLahir;
    document.getElementById("Pendidikan1").value = pendidikan;
    document.getElementById("NoHP1").value = noHp;
    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }

    $('#EditGuru').modal('show');
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