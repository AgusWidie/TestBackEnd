var Id = 0;

function SaveDataPengguna() {

    try {
        var NamaPengguna = document.getElementById("NamaPengguna").value;
        var IdGuru = document.getElementById("NamaGuru").value;
        var Password = document.getElementById("Password").value;
        var StatusPengguna = document.getElementById("StatusPengguna").value;
        var Email = document.getElementById("Email").value;
        var Deskripsi = document.getElementById("Deskripsi").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        var resultPassword = "";

        if (NamaPengguna == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran Kosong..!'
            })
            return;
        }

        if (IdGuru == "" || IdGuru == "0") {
            
            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Guru Kosong..!'
            })
            return;
        }

        if (Password == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password Kosong..!'
            })
            return;
        }

        if (Password.length < 8) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password minimal harus 8 karakter..!'
            })
            return;
        }

        if (Password.length > 15) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password tidak boleh lebih dari 15 karakter..!'
            })
            return;
        }

        resultPassword = checkPasswordValidation(Password);

        if (resultPassword != "Success") {
            alert(resultPassword.toString());
            return;
        }


        if (StatusPengguna == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Pengguna Kosong..!'
            })
            return;
        }

        if (StatusPengguna != "Admin" && StatusPengguna != "Administrasi" && StatusPengguna != "Guru") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Pengguna tidak valid..!, Status Pengguna --> ' + StatusPengguna
            })
            return;
        }

        if (Email == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Email Kosong..!'
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

        var data = { namaPengguna: NamaPengguna, idGuru: parseInt(IdGuru), pass: Password, statusPengguna: StatusPengguna, email: Email, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Pengguna/AddPengguna",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pengguna Berhasil Disimpan..!'
                    })
                    $('#TambahPengguna').modal('hide');
                    GetDataPengguna();
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

function UpdateDataPengguna() {

    try {

        var NamaPengguna = document.getElementById("NamaPengguna1").value;
        var IdGuru = document.getElementById("IdGuru1").value;
        var StatusPengguna = document.getElementById("StatusPengguna1").value;
        var Password = document.getElementById("Password1").value;
        var Email = document.getElementById("Email1").value;
        var Deskripsi = document.getElementById("Deskripsi1").value;
        var Aktif = document.getElementById("Aktif1").value;
        var bolAktif = false;

        var resultPassword = "";

        if (Id == "" || Id == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kosong..!'
            })
            return;
        }

        if (NamaPengguna == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran Kosong..!'
            })
            return;
        }

        if (IdGuru == "" || IdGuru == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Guru Kosong..!'
            })
            return;
        }

        if (Password == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password Kosong..!'
            })
            return;
        }

        if (Password.length < 8) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password minimal harus 8 karakter..!'
            })
            return;
        }

        if (Password.length > 15) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password tidak boleh lebih dari 15 karakter..!'
            })
            return;
        }

        resultPassword = checkPasswordValidation(Password);

        if (resultPassword != "Success") {
            alert(resultPassword.toString());
            return;
        }

        if (StatusPengguna == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Pengguna Kosong..!'
            })
            return;
        }

        if (StatusPengguna != "Admin" && StatusPengguna != "Administrasi" && StatusPengguna != "Guru") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Status Pengguna tidak valid..!, Status Pengguna --> ' + StatusPengguna
            })
            return;
        }

        if (Email == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Email Kosong..!'
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


        var data = { id: parseInt(Id), namaPengguna: NamaPengguna, idGuru: parseInt(IdGuru), pass: Password, statusPengguna: StatusPengguna, email: Email, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Pengguna/UpdatePengguna",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pengguna Berhasil Disimpan..!'
                    })
                    $('#EditPengguna').modal('hide');
                    GetDataPengguna();
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

function GetDataPengguna() {

    try {

        $("#tabelPengguna").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Pengguna/ListPengguna?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'namaPengguna', "autoWidth": true },
                { 'data': 'namaGuru', "autoWidth": true },
                { 'data': 'email', "autoWidth": true },
                { 'data': 'statusPengguna', "autoWidth": true },
                { 'data': 'expirePassword', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editPengguna(\'' + row.id + '\',\'' + row.namaPengguna + '\',\'' + row.idGuru + '\',\'' + row.namaGuru + '\',\'' + row.statusPengguna + '\',\'' + row.email + '\',\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editPengguna(id, namaPengguna, idGuru, namaGuru, statusPengguna, email, deskripsi, aktif) {
    Id = parseInt(id);

    document.getElementById("Id").value = id.toString();
    document.getElementById("NamaPengguna1").value = namaPengguna;
    document.getElementById("IdGuru1").value = idGuru.toString();
    document.getElementById("NamaGuru1").value = namaGuru;
    document.getElementById("StatusPengguna1").value = statusPengguna;
    document.getElementById("Email1").value = email;
    document.getElementById("Deskripsi1").value = deskripsi;

    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }
}

function checkPasswordValidation(value) {
    const isWhitespace = /^(?=.*\s)/;
    if (isWhitespace.test(value)) {
        return "Password tidak boleh ada spasi.";
    }


    const isContainsUppercase = /^(?=.*[A-Z])/;
    if (!isContainsUppercase.test(value)) {
        return "Password harus mengandung karakter huruf kapital.";
    }


    const isContainsLowercase = /^(?=.*[a-z])/;
    if (!isContainsLowercase.test(value)) {
        return "Password harus mengandung karakter huruf kecil.";
    }


    const isContainsNumber = /^(?=.*[0-9])/;
    if (!isContainsNumber.test(value)) {
        return "Password harus mengandung karakter angka.";
    }


    const isContainsSymbol =
        /^(?=.*[~`!@#$%^&*()--+={}\[\]|\\:;"'<>,.?/_₹])/;
    if (!isContainsSymbol.test(value)) {
        return "Password harus mengandung karakter spesial karakter.";
    }


    const isValidLength = /^.{8,15}$/;
    if (!isValidLength.test(value)) {
        return "Password harus minimal 8 karakter dan tidak boleh dari 15 karakter.";
    }

    return "Success";
}