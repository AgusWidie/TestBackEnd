var Id = 0;
var IdTahunAjaran;
var IdKelas;
var Hari;

function SaveDataJadwalPiketGuru() {

    try {
        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdGuru = document.getElementById("NamaGuru").value;
        var Hari = document.getElementById("Hari").value;
        var Deskripsi = document.getElementById("Deskripsi").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Tahun Ajaran Kosong..!'
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

        if (Hari == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Hari Kosong..!'
            })
            return;
        }

        if (Hari != "Senin" && Hari != "Selasa" && Hari != "Rabu" && Hari != "Kamis" && Hari != "Jum'at" && Hari != "Sabtu") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Hari tidak valid..! --> ' + Hari
            })
            return;

        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idGuru: parseInt(IdGuru), hari: Hari,  dekripsi: Deskripsi };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "JadwalPiketGuru/AddJadwalPiketGuru",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Jadwal Piket Guru Berhasil Disimpan..!'
                    })
                    $('#TambahJadwalPiketGuru').modal('hide');
                    GetDataJadwalPiketGuru();
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

function UpdateDataJadwalPiketGuru() {

    try {
        var IdTahunAjaran = document.getElementById("TahunAjaran1").value;
        var IdGuru = document.getElementById("IdGuru").value;
        var Hari = document.getElementById("Hari1").value;
        var Deskripsi = document.getElementById("Deskripsi1").value;

        if (Id == "" || Id == "0") {
            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kosong..!'
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

        if (IdGuru == "" || IdGuru == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Guru Kosong..!'
            })
            return;
        }

        if (Hari == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Hari Kosong..!'
            })
            return;
        }

        if (Hari != "Senin" && Hari != "Selasa" && Hari != "Rabu" && Hari != "Kamis" && Hari != "Jum'at" && Hari != "Sabtu") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Hari tidak valid..! --> ' + Hari
            })
            return;

        }
       
        var data = { id: parseInt(Id), idTahunAjaran: parseInt(IdTahunAjaran), idGuru: parseInt(IdGuru), hari: Hari, deskripsi: Deskripsi };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "JadwalPiketGuru/UpdateJadwalPiketGuru",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Jadwal Piket Guru Berhasil Disimpan..!'
                    })
                    $('#EditJadwalPiketGuru').modal('hide');
                    GetDataJadwalPiketGuru();
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

function GetDataJadwalPiketGuru() {

    try {

        var IdTahunAjaran = document.getElementById("TahunAjaran2").value;
        var IdGuru = document.getElementById("NamaGuru2").value;
        var Hari = document.getElementById("Hari2").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == null) {
            IdTahunAjaran = "0";
        }

        if (IdGuru == "" || IdGuru == null) {
            IdGuru = "0";
        }

        if (Hari == "" || Hari == null) {
            Hari = "";
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idGuru: parseInt(IdGuru), hari: Hari };
        var stringData = JSON.stringify(data);

        $("#tabelJadwalPiketGuru").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "JadwalPiketGuru/JadwalPiketGuruSearch",
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
                { 'data': 'namaGuru', "autoWidth": true },
                { 'data': 'hari', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editJadwalPiketGuru(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idGuru + '\',\'' + row.namaGuru + '\',\'' + row.hari + '\',\'' + row.dekripsi + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editJadwalPiketGuru(id, idTahunAjaran, tahunAjaran, idGuru, namaGuru, hari, deskripsi) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("IdTahunAjaran").value = idTahunAjaran.toString();
    document.getElementById("TahunAjaran1").value = tahunAjaran;
    document.getElementById("IdGuru").value = idGuru.toString();
    document.getElementById("NamaGuru1").value = namaGuru;
    document.getElementById("Hari1").value = hari;
    document.getElementById("Deskripsi1").value = deskripsi;

    $('#EditJadwalPiketGuru').modal('show');
}