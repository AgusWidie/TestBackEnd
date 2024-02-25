var Id = 0;
var IdTahunAjaran;
var IdKelas;

function SaveDataWaliKelas() {

    try {
        var IdGuru = document.getElementById("NamaGuru").value;
        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var Deskripsi = document.getElementById("Deskripsi").value;

        if (IdGuru == "" || IdGuru == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Guru Kosong..!'
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

        var data = { idGuru: parseInt(IdGuru), idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idTahunAjaran: parseInt(IdTahunAjaran), deskripsi: Deskripsi };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "WaliKelas/AddWaliKelas",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Wali Kelas Berhasil Disimpan..!'
                    })
                    $('#TambahWaliKelas').modal('hide');
                    GetDataWaliKelas();
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

function UpdateDataWaliKelas() {


    try {

        var IdGuru = document.getElementById("IdGuru").value;
        var IdTahunAjaran = document.getElementById("TahunAjaran1").value;
        var IdKelas = document.getElementById("NamaKelas1").value;
        var Deskripsi = document.getElementById("Deskripsi1").value;

        if (Id == "" || Id == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kosong..!'
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

        var data = { id: parseInt(Id), idGuru: parseInt(IdGuru), idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idTahunAjaran: parseInt(IdTahunAjaran), deskripsi: Deskripsi };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "WaliKelas/UpdateWaliKelas",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {
               
                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Wali Kelas Berhasil Disimpan..!'
                    })
                    $('#EditWaliKelas').modal('hide');
                    GetDataWaliKelas();
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

function GetDataWaliKelas() {

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

        $("#tabelWaliKelas").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "WaliKelas/WaliKelasSearch",
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
                { 'data': 'tahunAjaran', "autoWidth": true },
                { 'data': 'namaKelas', "autoWidth": true },
                { 'data': 'namaGuru', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editWaliKelas(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idGuru + '\',\'' + row.namaGuru + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.deskripsi + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editWaliKelas(id, idTahunAjaran, tahunAjaran, idGuru, namaGuru, idKelas, namaKelas, deskripsi) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("IdGuru").value = idGuru.toString();
    document.getElementById("NamaGuru1").value = namaGuru;
    document.getElementById("TahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("NamaKelas1").value = idKelas.toString();
    document.getElementById("Deskripsi1").value = deskripsi;

    $('#EditWaliKelas').modal('show');
}