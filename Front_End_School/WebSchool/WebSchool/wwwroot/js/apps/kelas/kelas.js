var Id = 0;

function SaveDataKelas() {

    try {
        var Kelas = document.getElementById("Kelas").value;
        var NamaKelas = document.getElementById("NamaKelas").value;
        var Aktif = document.getElementById("Aktif").value;
        var bolAktif = false;

        var number = /^[0-9]+$/;

        if (Kelas == "" || Kelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas Kosong..!'
            })
            return;

        }

        if (parseInt(Kelas) > 3) {
            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas tidak boleh lebih dari 3..!'
            })
            return;
        }

        if (!Kelas.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas tidak mengandung karakter angka..!'
            })
            return;
        }

        if (NamaKelas == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Kelas Kosong..!'
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

        var data = { kelas: parseInt(Kelas), namaKelas: NamaKelas, aktif: bolAktif };
        var stringData = JSON.stringify(data);
        //console.log("stringData : " + stringData);

        $.ajax({

            type: "POST",
            url: "Kelas/AddKelas",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {
                
                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Kelas Berhasil Disimpan..!'
                    })
                    $('#TambahKelas').modal('hide');
                    GetDataKelas();
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

function UpdateDataKelas() {

    try {
        var Kelas = document.getElementById("Kelas1").value;
        var NamaKelas = document.getElementById("NamaKelas1").value;
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

        if (Kelas == "" || Kelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas Kosong..!'
            })
            return;

        }

        if (parseInt(Kelas) > 3) {
            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas tidak boleh lebih dari 3..!'
            })
            return;
        }

        if (!Kelas.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas tidak mengandung karakter angka..!'
            })
            return;
        }

        if (NamaKelas == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Kelas Kosong..!'
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

        var data = { id: parseInt(Id), kelas: parseInt(Kelas), namaKelas: NamaKelas, aktif: bolAktif };
        var stringData = JSON.stringify(data);


        $.ajax({

            type: "POST",
            url: "Kelas/UpdateKelas",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Kelas Berhasil Disimpan..!'
                    })
                    $('#EditKelas').modal('hide');
                    GetDataKelas();
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

function GetDataKelas() {

    try {

        $("#tabelKelas").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Kelas/ListKelas?id=0",
                "type": "GET",
                "datatype": "json"
            },
            "columnDefs": [{
                "visible": true,
                "searchable": true
            }],
            columns: [
                { 'data': 'id', "autoWidth": true },
                { 'data': 'kelas', "autoWidth": true },
                { 'data': 'namaKelas', "autoWidth": true },
                { 'data': 'aktif', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editKelas(\'' + row.id + '\',\'' + row.kelas + '\',\'' + row.namaKelas + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editKelas(id, kelas, namaKelas, aktif) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("Kelas1").value = kelas.toString();
    document.getElementById("NamaKelas1").value = namaKelas;

    if (aktif == "true") {
        document.getElementById("Aktif1").value = "1";
    } else {
        document.getElementById("Aktif1").value = "0";
    }

    $('#EditKelas').modal('show');
}