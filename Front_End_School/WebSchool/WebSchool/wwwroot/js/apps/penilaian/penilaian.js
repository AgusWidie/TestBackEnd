var Id = 0;

function SaveDataPenilaian() {

    try {
        var IdPelajaran = document.getElementById("NamaPelajaran").value;
        var NamaPenilaian = document.getElementById("NamaPeilaian").value;
        var Deskripsi = document.getElementById("Deskripsi").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        if (IdPelajaran == "" || IdPelajaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Pelajaran Kosong..!'
            })
            return;
        }

        if (NamaPenilaian == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Penilaian Kosong..!'
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

        var data = { idPelajaran: parseInt(IdPelajaran), namaPenilaian: NamaPenilaian, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Penilaian/AddPenilaian",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {
                  
                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pelanggaran Berhasil Disimpan..!'
                    })
                    $('#TambahPenilaian').modal('hide');
                    GetDataPenilaian();
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

function UpdateDataPenilaian() {

    try {
        var Id = document.getElementById("Id").value;
        var IdPelajaran = document.getElementById("NamaPelajaran1").value;
        var NamaPenilaian = document.getElementById("NamaPeilaian1").value;
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

        if (IdPelajaran == "" || IdPelajaran == "0") {
          
            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Pelajaran Kosong..!'
            })
            return;
        }

        if (NamaPenilaian == "") {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Penilaian Kosong..!'
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

        var data = { id: parseInt(Id), idPelajaran: parseInt(IdPelajaran), namaPenilaian: NamaPenilaian, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Penilaian/UpdatePenilaian",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pelanggaran Berhasil Disimpan..!'
                    })
                    $('#EditPenilaian').modal('hide');
                    GetDataPenilaian();
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

function GetDataPenilaian() {

    try {

        $("#tabelPenilaian").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Penilaian/ListPenilaian?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'namaPelajaran', "autoWidth": true },
                { 'data': 'namaPenilaian', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editPenilaian(\'' + row.id + '\',\'' + row.idPelajaran + '\',\'' + row.namaPelajaran + '\',\'' + row.namaPenilaian + '\',\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editPenilaian(id, idPelajaran, namaPelajaran, namaPenilaian, deskripsi, aktif) {
    Id = parseInt(id);
    document.getElementById("Id").value = id;
    document.getElementById("NamaPelajaran1").value = idPelajaran;
    document.getElementById("NamaPenilaian1").value = namaPenilaian;
    document.getElementById("Deskripsi1").value = deskripsi;

    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }

    $('#EditPenilaian').modal('show');

}