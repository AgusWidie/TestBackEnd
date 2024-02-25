
var Id = 0;
var IdTahunAjaran;
var IdKelas;
var AbsenMasuk;

function SaveDataAbsenGuru() {


    try {
        var IdGuru = document.getElementById("IdGuru").value;
        var IdTahunAjaran = document.getElementById("IdTahunAjaran").value;
        var IdKelas = document.getElementById("IdKelas").value;
        var NamaAbsen = document.getElementById("Absen").value;
        var AbsenMasuk = document.getElementById("AbsenMasuk").value;
        var AbsenKeluar = document.getElementById("AbsenKeluar").value;

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

        if (NamaAbsen == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Absen Kosong..!'
            })
            return;
        }

        if (NamaAbsen != "Masuk" && NamaAbsen != "Alpha" && NamaAbsen != "Izin" && NamaAbsen != "Sakit" && NamaAbsen != "Cuti") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Absen tidak valid..!, Absen --> ' + NamaAbsen
            })
            return;
        }

        if (AbsenMasuk == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Absen Masuk..!'
            })
            return;
        }

        if (AbsenKeluar == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Absen Keluar Kosong..!'
            })
            return;
        }

        var data = { id: parseInt(Id), idGuru: parseInt(IdGuru), idKelas: parseInt(IdKelas), idTahunAjaran: parseInt(IdTahunAjaran), namaAbsen: NamaAbsen, absenMasuk: AbsenMasuk, absenKeluar: AbsenKeluar };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "AbsenGuru/UpdateAbsenGuru",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",

            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Absen Guru Berhasil Disimpan..!'
                    })
                    $('#EditAbsenGuru').modal('hide');
                    GetDataAbsenGuru();
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

function GetDataAbsenGuru() {

    try {

        IdTahunAjaran = document.getElementById("TahunAjaran2").value;
        IdKelas = document.getElementById("NamaKelas2").value;
        AbsenMasuk = document.getElementById("AbsenMasuk2").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == null) {
            IdTahunAjaran = "0";
        }

        if (IdKelas == "" || IdKelas == null) {
            IdKelas = "0";
        }

        if (AbsenMasuk == null) {
            AbsenMasuk = new Date("2012-01-26 00:00:00").toISOString();
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), absenMasuk: AbsenMasuk };
        var stringData = JSON.stringify(data);

        $("#tabelAbsenGuru").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "AbsenGuru/AbsenGuruSearch",
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
                { 'data': 'namaGuru', "autoWidth": true },
                { 'data': 'tahunAjaran', "autoWidth": true },
                { 'data': 'namaKelas', "autoWidth": true },
                { 'data': 'absen', "autoWidth": true },
                { 'data': 'absenMasuk', "autoWidth": true },
                { 'data': 'absemKeluar', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editAbsenGuru(\'' + row.id + '\',\'' + row.idGuru + '\',\'' + row.namaGuru + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.absen + '\',\'' + row.absenMasuk + '\',\'' + row.absenKeluar + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editAbsenGuru(id, idGuru, namaGuru, idTahunAjaran, tahunAjaran, idKelas, namaKelas, absen, absenMasuk, absenKeluar) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("IdGuru").value = idGuru.toString();
    document.getElementById("NamaGuru").value = namaGuru;
    document.getElementById("IdTahunAjaran").value = idTahunAjaran.toString();
    document.getElementById("TahunAjaran").value = tahunAjaran;
    document.getElementById("IdKelas").value = idKelas.toString();
    document.getElementById("NamaKelas").value = namaKelas;
    document.getElementById("Absen").value = absen;
    document.getElementById("AbsenMasuk").value = absenMasuk;
    document.getElementById("AbsenKeluar").value = absenKeluar;

    $('#EditAbsenGuru').modal('show');
}