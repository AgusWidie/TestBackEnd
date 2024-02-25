var Id = 0;

function SaveDataPengggunaPeran() {

    try {
        var IdPengguna = document.getElementById("NamaPengguna").value;
        var IdPeran = document.getElementById("NamaPeran").value;
        var Deskripsi = document.getElementById("Deskripsi").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        if (IdPengguna == "" || IdPengguna == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Pengguna Kosong..!'
            })
            return;
        }

        if (IdPeran == "" || IdPeran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Peran Kosong..!'
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

        var data = { idPengguna: parseInt(IdPengguna), idPeran: parseInt(IdPeran), deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "PenggunaRole/AddPenggunaRole",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {
                    
                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pengguna Peran Berhasil Disimpan..!'
                    })
                    $('#TambahPenggunaPeran').modal('hide');
                    GetDataPenggunaRole();
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

function UpdateDataPengggunaPeran() {


    try {

        var IdPengguna = document.getElementById("IdPengguna").value;
        var IdPeran = document.getElementById("NamaPeran1").value;
        var Deskripsi = document.getElementById("Deskripsi1").value;
        var Aktif = document.getElementById("Aktif1").value;
        var bolAktif = false;

        if (Id == "" || Id == "0") {
          
            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kosong..!'
            })
            return;
        }

        if (IdPengguna == "" || IdPengguna == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Pengguna Kosong..!'
            })
            return;
        }

        if (IdPeran == "" || IdPeran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Peran Kosong..!'
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

        var data = { id: parseInt(Id), idPengguna: parseInt(IdPengguna), idPeran: parseInt(IdPeran), deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "PenggunaRole/UpdatePenggunaRole",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pengguna Peran Berhasil Disimpan..!'
                    })
                    $('#EditPenggunaPeran').modal('hide');
                    GetDataPenggunaRole();
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

function GetDataPenggunaRole() {

    try {

        $("#tabelPenggunaRole").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "tabelPenggunaRole/ListPenggunaRole?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'namaPengguna', "autoWidth": true },
                { 'data': 'namaRole', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editPenggunaRole(\'' + row.id + '\',\'' + row.idPengguna + '\',\'' + row.namaPengguna + '\',\'' + row.idRole + '\',\'' + row.namaRole + '\',\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editPenggunaRole(id, idPengguna, namaPengguna, idRole, namaRole, deskripsi, aktif) {
    Id = parseInt(id);

    document.getElementById("Id").value = id;
    document.getElementById("IdPengguna").value = idPengguna.toString();
    document.getElementById("NamaPengguna1").value = namaPengguna;
    document.getElementById("NamaPeran1").value = idRole.toString();
    document.getElementById("Deskripsi1").value = deskripsi;

    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }
}