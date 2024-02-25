var Id = 0;
var IdTahunAjaran;
var IdKelas;
var TanggalAbsen;

function SaveDataAbsenSiswa() {

    try {
        var IdSiswa = document.getElementById("IdSiswa").value;
        var IdTahunAjaran = document.getElementById("IdTahunAjaran").value;
        var IdKelas = document.getElementById("IdKelas").value;
        var NamaAbsen = document.getElementById("Absen").value;
        var TanggalAbsen = document.getElementById("TanggalAbsen").value;

        if (Id == "" || Id == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kosong..!'
            })
            return;
        }

        if (IdSiswa == "" || IdSiswa == "0") {

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

        if (NamaAbsen != "Masuk" && NamaAbsen != "Alpha" && NamaAbsen != "Izin" && NamaAbsen != "Sakit") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Absen tidak valid..!, Absen --> ' + NamaAbsen
            })
            return;
        }

        var data = { id: parseInt(Id), idSiswa: parseInt(IdSiswa), idKelas: parseInt(IdKelas), idTahunAjaran: parseInt(IdTahunAjaran), namaAbsen: NamaAbsen, tanggalAbsen: TanggalAbsen };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "AbsenSiswa/UpdateAbsenSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Absen Siswa Berhasil Disimpan..!'
                    })
                    $('#EditAbsenSiswa').modal('hide');
                    GetDataAbsenSiswa();
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

function GetDataAbsenSiswa() {

    try {

        IdTahunAjaran = document.getElementById("TahunAjaran2").value;
        IdKelas = document.getElementById("NamaKelas2").value;
        TanggalAbsen = document.getElementById("TanggalAbsen2").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == null) {
            IdTahunAjaran = "0";
        }

        if (IdKelas == "" || IdKelas == null) {
            IdKelas = "0";
        }

        if (TanggalAbsen == null) {
            TanggalAbsen = new Date("2012-01-26 00:00:00").toISOString();
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), tanggalAbsen: TanggalAbsen };
        var stringData = JSON.stringify(data);

        $("#tabelAbsenSiswa").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "AbsenSiswa/AbsenSiswaSearch",
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
                { 'data': 'namaSiswa', "autoWidth": true },
                { 'data': 'tahunAjaran', "autoWidth": true },
                { 'data': 'namaKelas', "autoWidth": true },
                { 'data': 'absen', "autoWidth": true },
                { 'data': 'tanggalAbsen', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editAbsenSiswa(\'' + row.id + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.absen + '\',\'' + row.tanggalAbsen + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editAbsenSiswa(id, idSiswa, namaSiswa, idTahunjaran, tahunAjaran, idKelas, namaKelas, absen, tanggalAbsen) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("IdSiswa").value = idSiswa.toString();
    document.getElementById("NamaSiswa").value = namaSiswa;
    document.getElementById("IdTahunjaran").value = idTahunjaran.toString();
    document.getElementById("TahunAjaran").value = tahunAjaran;
    document.getElementById("IdKelas").value = idKelas.toString();
    document.getElementById("NamaKelas").value = namaKelas;
    document.getElementById("Absen").value = absen;
    document.getElementById("TanggalAbsen").value = tanggalAbsen;

    $('#EditAbsenSiswa').modal('show');
}