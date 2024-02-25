var Id = 0;

function SaveDataPelajaran() {

    try {
        var NamaPelajaran = document.getElementById("NamaPelajaran").value;
        var Deskripsi = document.getElementById("Deskripsi").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        if (NamaPelajaran == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pelajaran Kosong..!'
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

        var data = { namaPelajaran: NamaPelajaran, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Pelajaran/AddPelajaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pelajaran Berhasil Disimpan..!'
                    })
                    $('#TambahPelajaran').modal('hide');
                    GetDataPelajaran();
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

function UpdateDataPelajaran() {

    try {
        var NamaPelajaran = document.getElementById("NamaPelajaran1").value;
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

        if (NamaPelajaran == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pelajaran Kosong..!'
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

        var data = { id: parseInt(Id), namaPelajaran: NamaPelajaran, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);


        $.ajax({

            type: "POST",
            url: "Pelajaran/UpdatePelajaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pelajaran Berhasil Disimpan..!'
                    })
                    $('#EditPelajaran').modal('hide');
                    GetDataPelajaran();
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

function GetDataPelajaran() {

    try {

        $("#tabelPelajaran").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Pelajaran/ListPelajaran?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'id', "autoWidth": true },
                { 'data': 'namaPelajaran', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editPelajaran(\'' + row.id + '\',\'' + row.namaPelajaran + '\',\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
}

function editPelajaran(id, namaPelajaran, deskripsi, aktif) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("NamaPelajaran1").value = namaPelajaran;
    document.getElementById("Deskripsi1").value = deskripsi;
    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }
    $('#EditPelajaran').modal('show');
}

