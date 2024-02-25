var Id = 0;
var IdTahunAjaran;
var IdKelas;
var IdPelajaran;

function SaveDataJadwalGuruMengajar() {

    try {
        var IdGuru = document.getElementById("NamaGuru").value;
        var Hari = document.getElementById("Hari").value;
        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var IdPelajaran = document.getElementById("NamaPelajaran").value;
        var DariJam = document.getElementById("DariJam").value;
        var SampaiJam = document.getElementById("SampaiJam").value;

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

        if (IdPelajaran == "" || IdPelajaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Pelajaran Kosong..!'
            })
            return;
        }

        if (DariJam == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Dari Jam Kosong..!'
            })
            return;
        }

        if (SampaiJam == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Sampai Jam Kosong..!'
            })
            return;
        }

        var data = { idGuru: parseInt(IdGuru), hari: Hari, idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idPelajaran: parseInt(IdPelajaran), dariJam: DariJam, sampaiJam: SampaiJam };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "JadwalGuru/AddJadwalGuru",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Jadwal Guru Berhasil Disimpan..!'
                    })
                    $('#TambahJadwalGuru').modal('hide');
                    GetDataJadwalGuru();
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

function UpdateDataJadwalGuruMengajar() {

    try {
  
        var IdGuru = document.getElementById("IdGuru").value;
        var Hari = document.getElementById("Hari1").value;
        var IdTahunAjaran = document.getElementById("IdTahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas1").value;
        var IdPelajaran = document.getElementById("NamaPelajaran1").value;
        var DariJam = document.getElementById("DariJam1").value;
        var SampaiJam = document.getElementById("SampaiJam1").value;

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

        if (IdPelajaran == "" || IdPelajaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Pelajaran Kosong..!'
            })
            return;
        }

        if (DariJam == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Dari Jam Kosong..!'
            })
            return;
        }

        if (SampaiJam == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Sampai Jam Kosong..!'
            })
            return;
        }

        var data = { id: parseInt(Id), idGuru: parseInt(IdGuru), hari: Hari, idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idPelajaran: parseInt(IdPelajaran), dariJam: DariJam, sampaiJam: SampaiJam };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "JadwalGuru/UpdateJadwalGuru",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Jadwal Guru Berhasil Disimpan..!'
                    })
                    $('#EditJadwalGuru').modal('hide');
                    GetDataJadwalGuru();
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

function GetDataJadwalGuru() {

    try {

        IdTahunAjaran = document.getElementById("TahunAjaran2").value;
        IdKelas = document.getElementById("NamaKelas2").value;
        IdPelajaran = document.getElementById("NamaPelajaran2").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == null) {
            IdTahunAjaran = "0";
        }

        if (IdKelas == "" || IdKelas == null) {
            IdKelas = "0";
        }

        if (IdPelajaran == "" || IdPelajaran == null) {
            IdPelajaran = "0";
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idPelajaran: parseInt(IdPelajaran) };
        var stringData = JSON.stringify(data);

        $("#tabelJadwalGuru").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "JadwalGuru/JadwalGuruSearch",
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
                { 'data': 'hari', "autoWidth": true },
                { 'data': 'namaPelajaran', "autoWidth": true },
                { 'data': 'dariJam', "autoWidth": true },
                { 'data': 'sampaiJam', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editJadwalGuru(\'' + row.id + '\',\'' + row.idGuru + '\',\'' + row.namaGuru + '\',\'' + row.hari + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.idPelajaran + '\',\'' + row.namaPelajaran + '\',\'' + row.dariJam + '\',\'' + row.sampaiJam + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editJadwalGuru(id, idGuru, namaGuru, hari, idTahunAjaran, tahunAjaran, idKelas, namaKelas, idPelajaran, namaPelajaran, dariJam, sampaiJam) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("IdGuru").value = idGuru.toString();
    document.getElementById("NamaGuru1").value = namaGuru;
    document.getElementById("Hari1").value = hari;
    document.getElementById("TahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("NamaKelas1").value = idKelas.toString();
    document.getElementById("NamaPelajaran1").value = idPelajaran.toString();
    document.getElementById("DariJam1").value = dariJam.toString();
    document.getElementById("SampaiJam1").value = sampaiJam.toString();

    $('#EditJadwalGuru').modal('show');
}