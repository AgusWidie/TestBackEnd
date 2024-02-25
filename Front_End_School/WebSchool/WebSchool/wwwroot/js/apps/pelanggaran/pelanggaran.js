var Id = 0;

function SaveDataPelanggaran() {

    try {
        var NamaPelanggaran = document.getElementById("NamaPelanggaran").value;
        var Poin = document.getElementById("Poin").value;
        var Deskripsi = document.getElementById("Deskripsi").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        var number = /^[0-9]+$/;

        if (NamaPelanggaran == "") {
            
            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pelanggaran Kosong..!'
            })
            return;
        }

        if (Poin == "" || Poin == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Poin Kosong..!'
            })
            return;
        }

        if (!Poin.match(number)) {
         
            Swal.fire({
                title: 'Informasi..!',
                text: 'Poin tidak mengandung karakter angka..!'
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

        var data = { namaPelanggaran: NamaPelanggaran, poin: parseInt(Poin), deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Pelanggaran/AddPelanggaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pelanggaran Berhasil Disimpan..!'
                    })
                    $('#TambahPelanggaran').modal('hide');
                    GetDataPelanggaran();
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

function UpdateDataPelanggaran() {

    try {
        var NamaPelanggaran = document.getElementById("NamaPelanggaran1").value;
        var Poin = document.getElementById("Poin1").value;
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

        if (NamaPelanggaran == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pelanggaran Kosong..!'
            })
            return;
        }

        if (Poin == "" || Poin == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Poin Kosong..!'
            })
            return;
        }

        if (!Poin.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Poin tidak mengandung karakter angka..!'
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

        var data = { id: parseInt(Id), namaPelanggaran: NamaPelanggaran, poin: parseInt(Poin), deskripsi: Deskripsi, aktif: bolAktif };
        var stringData = JSON.stringify(data);


        $.ajax({

            type: "POST",
            url: "Pelanggaran/UpdatePelanggaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pelanggaran Berhasil Disimpan..!'
                    })
                    $('#EditPelanggaran').modal('hide');
                    GetDataPelanggaran();
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

function GetDataPelanggaran() {

    try {

        $("#tabelPelanggaran").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Pelanggaran/ListPelanggaran?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'id', "autoWidth": true },
                { 'data': 'namaPelanggaran', "autoWidth": true },
                { 'data': 'poin', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editPelanggaran(\'' + row.id + '\',\'' + row.namaPelanggaran + '\',\'' + row.poin + '\'\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editPelanggaran(id, namaPelanggaran, poin, deskripsi, aktif) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("NamaPelanggaran1").value = namaPelanggaran;
    document.getElementById("Poin1").value = poin.toString();
    document.getElementById("Deskripsi1").value = deskripsi;
    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }
    $('#EditPelanggaran').modal('show');
}