var Id = 0;
var TerminalBuat;
var TerminalPerbarui;

function SaveDataTahunAjaran() {

    try {
        var TahunAjaran = document.getElementById("TahunAjaran").value;
        var Deskripsi = document.getElementById("Deskripsi").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        var number = /^[0-9]+$/;
        var TahunSekarang = new Date().getFullYear();

        if (TahunAjaran == "") {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran masih kosong..!'
            })
            return;
        }

        if (TahunAjaran.length < 9 || TahunAjaran.length > 9) {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran harus 9 karakter..!'
            })
            return;
        }

        const dataSplit = TahunAjaran.split("-");
        var TahunAjaran1 = dataSplit[0].toString();
        var TahunAjaran2 = dataSplit[1].toString();
        
        if (!TahunAjaran1.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran 4 karakter pertama harus mengandung angka..!'
            })
            return;
        }

        if (!TahunAjaran2.match(number)) {
            
            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran 4 karakter selanjutnya harus mengandung angka..!'
            })
            return;
        }

        if (parseInt(TahunAjaran1) < TahunSekarang) {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun tidak boleh kecil dari Tahun Sekarang..!'
            })
            return;
        }

        if (parseInt(TahunAjaran1) < parseInt(TahunAjaran2)) {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun tidak boleh sama atau lebih kecil dari tahun sebelumnya..!'
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

        var data = { tahunAjaran: TahunAjaran, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "TahunAjaran/AddTahunAjaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Tahun Ajaran Berhasil Disimpan..!'
                    })
                    $('#TambahTahunAjaran').modal('hide');
                    GetDataTahunAjaran();
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

function UpdateDataTahunAjaran() {

    try {
        
        var TahunAjaran = document.getElementById("TahunAjaran1").value;
        var Deskripsi = document.getElementById("Deskripsi1").value;
        var Aktif = document.getElementById("Aktif1").value;
        var bolAktif = false;

        var number = /^[0-9]+$/;
        var TahunSekarang = new Date().getFullYear();

        if (Id == "" || Id == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id masih kosong..!'
            })
            return;
        }

        if (TahunAjaran == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran masih kosong..!'
            })
            return;
        }

        if (TahunAjaran.length < 9 || TahunAjaran.length > 9) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran harus 9 karakter..!'
            })
            return;
        }

        const dataSplit = TahunAjaran.split("-");
        var TahunAjaran1 = dataSplit[0].toString();
        var TahunAjaran2 = dataSplit[1].toString();

        console.log("TahunAjaran1 --> " + TahunAjaran1);
        console.log("strip --> " + strip);
        console.log("TahunAjaran2 --> " + TahunAjaran2);

        if (!TahunAjaran1.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran 4 karakter pertama harus mengandung angka..!'
            })
            return;
        }

        if (!TahunAjaran2.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran 4 karakter selanjutnya harus mengandung angka..!'
            })
            return;
        }

        if (parseInt(TahunAjaran1) < TahunSekarang) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun tidak boleh kecil dari Tahun Sekarang..!'
            })
            return;
        }

        if (parseInt(TahunAjaran1) < parseInt(TahunAjaran2)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun tidak boleh sama atau lebih kecil dari tahun sebelumnya..!'
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


        var data = { id: parseInt(Id), tahunAjaran: TahunAjaran, deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "TahunAjaran/UpdateTahunAjaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Tahun Ajaran Berhasil Disimpan..!'
                    })
                    $('#EditTahunAjaran').modal('hide');
                    GetDataTahunAjaran();
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

function GetDataTahunAjaran() {

    try {

        $("#tabelTahunAjaran").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "TahunAjaran/ListTahunAjaran?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'id', "autoWidth": true },
                { 'data': 'tahunAjaran', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editTahunAjaran(\'' + row.id + '\',\'' + row.tahunAjaran + '\',\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });

        
    }
    catch (err) {
        alert(err.toString());
    }
} 

function editTahunAjaran(id, tahunAjaran, deskripsi, aktif) {
    Id = parseInt(id);

    document.getElementById("Id").value = id;
    document.getElementById("TahunAjaran1").value = tahunAjaran;
    document.getElementById("Deskripsi1").value = deskripsi;
    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }
    $('#EditTahunAjaran').modal('show');
}
   