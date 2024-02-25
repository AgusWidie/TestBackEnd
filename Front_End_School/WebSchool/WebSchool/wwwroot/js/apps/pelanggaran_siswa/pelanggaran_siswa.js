var Id = 0;
var IdTahunAjaran;
var IdKelas;
var IdSiswa;


function SaveDataPelanggaranSiswa() {

    try {

        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var IdSiswa = document.getElementById("NamaSiswa").value;
        var IdPelanggaran = document.getElementById("NamaPelanggaran").value;
        var Deskripsi = document.getElementById("Deskripsi").value;

        if (IdSiswa == "" || IdSiswa == "0") {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Siswa Kosong..!'
            })
            return;

        }

        if (IdPelanggaran == "" || IdPelanggaran == "0") {
            
            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pelanggaran Kosong..!'
            })
            return;
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), idPelanggaran: parseInt(IdPelanggaran), deskripsi: Deskripsi };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "PelanggaranSiswa/AddPelanggaranSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pelanggaran Siswa Berhasil Disimpan..!'
                    })
                    $('#TambahPelanggaranSiswa').modal('hide');
                    GetDataPelanggaranSiswa();
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
        var IdTahunAjaran = document.getElementById("IdTahunAjaran1").value;
        var IdKelas = document.getElementById("IdKelas1").value;
        var IdSiswa = document.getElementById("IdSiswa1").value;
        var IdPelanggaran = document.getElementById("NamaPelanggaran1").value;
        var Deskripsi = document.getElementById("Deskripsi1").value;

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
                text: 'Nama Siswa Kosong..!'
            })
            return;

        }

        if (IdPelanggaran == "" || IdPelanggaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pelanggaran Kosong..!'
            })
            return;
        }

        var data = { id: parseInt(Id), idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), idPelanggaran: parseInt(IdPelanggaran), deskripsi: Deskripsi };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "PelanggaranSiswa/UpdatePelanggaranSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pelanggaran Siswa Berhasil Disimpan..!'
                    })
                    $('#EditPelanggaranSiswa').modal('hide');
                    GetDataPelanggaranSiswa();
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

function GetDataPelanggaranSiswa() {

    try {

        IdTahunAjaran = document.getElementById("TahunAjaran2").value;
        IdKelas = document.getElementById("NamaKelas2").value;
        IdSiswa = document.getElementById("NamaSiswa2").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == null) {
            IdTahunAjaran = "0";
        }

        if (IdKelas == "" || IdKelas == null) {
            IdKelas = "0";
        }

        if (IdSiswa == "" || IdSiswa == null) {
            IdSiswa = "0";
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa) };
        var stringData = JSON.stringify(data);


        $("#tabelPelanggaranSiswa").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "PelanggaranSiswa/PelanggaranSiswaSearch",
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
                { 'data': 'namaSiswa', "autoWidth": true },
                { 'data': 'namaPelanggaran', "autoWidth": true },
                { 'data': 'poin', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editPelanggaranSiswa(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.idPelanggaran + '\',\'' + row.namaPelanggaran + '\',\'' + row.poin + '\',\'' + row.deskripsi + '\',\'' + row.aktif + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editPelanggaranSiswa(id, idTahunAjaran, tahunAjaran, idKelas, namaKelas, idSiswa, namaSiswa, idPelanggaran, namaPelanggaran, poin, deskripsi) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("IdTahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("TahunAjaran1").value = tahunAjaran;
    document.getElementById("IdKelas1").value = idKelas.toString();
    document.getElementById("NamaKelas1").value = namaKelas;
    document.getElementById("IdSiswa1").value = idSiswa.toString();
    document.getElementById("NamaSiswa1").value = namaSiswa;
    document.getElementById("NamaPelanggaran1").value = idPelanggaran.toString();
    document.getElementById("Deskripsi1").value = deskripsi;

    $('#EditPelanggaranSiswa').modal('show');
}

function GetSiswaAddData() {
    try {

        var IdTahunAjaran = document.getElementById("TahunaAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas) };
        var stringData = JSON.stringify(data);

        select = document.getElementById('NamaSiswa');
        var optDefault = document.createElement('option');
        optDefault.value = "0";
        optDefault.innerHTML = "";
        select.appendChild(optDefault);

        $.ajax({

            type: "POST",
            url: "Siswa/SiswaSearch",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {

                if (responseData.error == false) {
                    for (var i = 0; i < responseData.data.length; i++) {

                        var obj = responseData.data[i];
                        var opt = document.createElement('option');
                        opt.value = obj.id.toString();
                        opt.innerHTML = obj.namaSiswa;
                        select.appendChild(opt);
                    }
                } else {

                }

            },
            error: function (error) {
                alert(error.toString());
            }
        });
    }
    catch (err) {
        alert(err.toString());
    }

}

function GetSiswaSearchData() {
    try {

        var IdTahunAjaran = document.getElementById("TahunaAjaran2").value;
        var IdKelas = document.getElementById("NamaKelas2").value;
        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas) };
        var stringData = JSON.stringify(data);

        select = document.getElementById('NamaSiswa2');
        var optDefault = document.createElement('option');
        optDefault.value = "0";
        optDefault.innerHTML = "";
        select.appendChild(optDefault);

        $.ajax({

            type: "POST",
            url: "Siswa/SiswaSearch",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {

                if (responseData.error == false) {
                    for (var i = 0; i < responseData.data.length; i++) {

                        var obj = responseData.data[i];
                        var opt = document.createElement('option');
                        opt.value = obj.id.toString();
                        opt.innerHTML = obj.namaSiswa;
                        select.appendChild(opt);
                    }
                } else {

                }

            },
            error: function (error) {
                alert(error.toString());
            }
        });
    }
    catch (err) {
        alert(err.toString());
    }

}


