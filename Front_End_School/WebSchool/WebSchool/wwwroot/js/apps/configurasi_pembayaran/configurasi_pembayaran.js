function SaveDataConfigurasiPembayaran() {

    try {
        var NamaPembayaran = document.getElementById("NamaPembayaran").value;
        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var Kelas = document.getElementById("Kelas").value;
        var NilaiPembayaran = document.getElementById("NilaiPembayaran").value;
        var Deskripsi = document.getElementById("Deskripsi").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        var number = /^[0-9]+$/;

        if (NamaPembayaran == "") {
         
            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran Kosong..!'
            })
            return;
        }

        if (NamaPembayaran != "Uang Bangunan" && NamaPembayaran != "Daftar Ulang" && NamaPembayaran != "SPP" && NamaPembayaran != "Semester Ganjil" && NamaPembayaran != "Semester Genap" || NamaPembayaran != "Praktek Kerja Lapangan" && NamaPembayaran != "Seragam") {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran Tidak Terdaftar..!, "' + NamaPembayaran + '"'
            })
            return;
        }

        if (NamaPembayaran == "UangBangunan") {
            Kelas = "0";
        }

        if (IdTahunAjaran == "" || IdTahunAjaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Tahun Ajaran Kosong..!'
            })
            return;
        }

        if (Kelas == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas Kosong..!'
            })
            return;
        }

        if (Kelas !== "0" && Kelas !== "1" && Kelas !== "2" && Kelas !== "3") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas tidak valid..!, kelas --> ' + Kelas
            })
            return;
        }

        if (NilaiPembayaran == "" || NilaiPembayaran == "0") {
         
            Swal.fire({
                title: 'Informasi..!',
                text: 'Nilai Pembayaran Kosong..!'
            })
            return;
        }

        if (!NilaiPembayaran.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nilai Pembayaran tidak mengandung angka..!'
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

        var data = { namaPembayaran: NamaPembayaran, idTahunAjaran: parseInt(IdTahunAjaran), kelas: parseInt(Kelas), nilaiPembayaran: parseInt(NilaiPembayaran), deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "ConfigurasiPembayaran/AddConfigurasiPembayaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {
                    

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Configurasi Pembayaran Berhasil Disimpan..!'
                    })
                    $('#TambahConfig').modal('hide');
                    GetDataConfigPembayaran();
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

function UpdateDataConfigurasiPembayaran() {

    try {
        var Id = document.getElementById("Id").value;
        var NamaPembayaran = document.getElementById("NamaPembayaran1").value;
        var IdTahunAjaran = document.getElementById("TahunAjaran1").value;
        var Kelas = document.getElementById("Kelas1").value;
        var NilaiPembayaran = document.getElementById("NilaiPembayaran1").value;
        var Deskripsi = document.getElementById("Deskripsi1").value;
        var Aktif = document.getElementById("Aktif1").value;
        var bolAktif = false;

        var number = /^[0-9]+$/;

        if (Id == "" || Id == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Kosong..!'
            })
            return;

        }

        if (NamaPembayaran == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran Kosong..!'
            })
            return;
        }

        if (NamaPembayaran != "Uang Bangunan" && NamaPembayaran != "Daftar Ulang" && NamaPembayaran != "SPP" && NamaPembayaran != "Semester Ganjil" && NamaPembayaran != "Semester Genap" || NamaPembayaran != "Praktek Kerja Lapangan" && NamaPembayaran != "Seragam") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran Tidak Terdaftar..!, "' + NamaPembayaran + '"'
            })
            return;
        }

        if (NamaPembayaran == "UangBangunan") {
            Kelas = "0";
        }

        if (IdTahunAjaran == "" || IdTahunAjaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Tahun Ajaran Kosong..!'
            })
            return;
        }

        if (Kelas == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas Kosong..!'
            })
            return;
        }

        if (Kelas !== "0" && Kelas !== "1" && Kelas !== "2" && Kelas !== "3") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas tidak valid..!, kelas --> ' + Kelas
            })
            return;
        }

        if (NilaiPembayaran == "" || NilaiPembayaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nilai Pembayaran Kosong..!'
            })
            return;
        }

        if (!NilaiPembayaran.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nilai Pembayaran tidak mengandung angka..!'
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

        var data = { id: parseInt(Id), namaPembayaran: NamaPembayaran, idTahunAjaran: parseInt(IdTahunAjaran), kelas: parseInt(Kelas), nilaiPembayaran: parseInt(NilaiPembayaran), deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "ConfigurasiPembayaran/UpdateConfigurasiPembayaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {


                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Configurasi Pembayaran Berhasil Disimpan..!'
                    })
                    $('#EditConfig').modal('hide');
                    GetDataConfigPembayaran();
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

function GetDataConfigPembayaran() {

    try {

        $("#tabelConfigurasiPembayaran").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "ConfigurasiPembayaran/ListConfigurasiPembayaran?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'pembayaran', "autoWidth": true },
                { 'data': 'tahunAjaran', "autoWidth": true },
                { 'data': 'kelas', "autoWidth": true },
                { 'data': 'nilaiPembayaran', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editConfigurasiPembayaran(\'' + row.id + '\',\'' + row.pembayaran + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.kelas + '\',\'' + row.nilaiPembayaran + '\',\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editConfigurasiPembayaran(id, pembayaran, idTahunAjaran, tahunAjaran, kelas, nilaiPembayaran, deskripsi, aktif) {
    Id = parseInt(id);

    document.getElementById("Id").value = id;
    document.getElementById("NamaPembayaran1").value = pembayaran;
    document.getElementById("TahunAjaran1").value = idTahunAjaran;
    document.getElementById("Kelas1").value = kelas;
    document.getElementById("NilaiPembayaran1").value = nilaiPembayaran;
    document.getElementById("Deskripsi1").value = deskripsi;
    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }

    $('#EditConfig').modal('show');
}