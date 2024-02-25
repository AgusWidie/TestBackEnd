var Id = 0;

function SaveDataPeran() {

    try {
        var NamaPeran = document.getElementById("NamaPeran").value;
        var Deskripsi = document.getElementById("Deskripsi").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        if (NamaPeran == "") {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Peran Kosong..!'
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

        var data = { namaPeran: NamaPeran, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Role/AddRole",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Peran Berhasil Disimpan..!'
                    })
                    $('#TambahPeran').modal('hide');
                    GetDataRole();
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

function UpdateDataPeran() {

    try {

        var NamaPeran = document.getElementById("NamaPeran1").value;
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

        if (NamaPeran == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Peran Kosong..!'
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

        var data = { id: parseInt(Id), namaPeran: NamaPeran, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Role/UpdateRole",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Peran Berhasil Disimpan..!'
                    })
                    $('#EditPeran').modal('hide');
                    GetDataRole();
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

function GetDataRole() {

    try {

        $("#tabelRole").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Role/ListRole?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'id', "autoWidth": true },
                { 'data': 'namaRole', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editRole(\'' + row.id + '\',\'' + row.namaRole + '\',\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editRole(id, namaRole, deskripsi, aktif) {
    Id = parseInt(id)
    document.getElementById("Id").value = id;
    document.getElementById("NamaPeran1").value = namaRole;
    document.getElementById("Deskripsi1").value = deskripsi;

    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }

    $('#EditPeran').modal('show');
}