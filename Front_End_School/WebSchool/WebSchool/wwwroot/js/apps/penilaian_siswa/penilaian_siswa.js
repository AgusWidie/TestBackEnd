var Id = 0;
var IdTahunAjaran;
var IdKelas;
var IdSiswa;

function SaveDatPenilaianSiswa() {

    try {

        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var IdSiswa = document.getElementById("NamaSiswa").value;
        var IdPenilaian = document.getElementById("NamaPenilaian").value;
        var Nilai = document.getElementById("Nilai").value;
        var Deskripsi = document.getElementById("Deskripsi").value;

        var number = /^[0-9]+$/;

        if (IdTahunAjaran == "" || IdTahunAjaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Ajaran Kosong..!'
            })
            return;
        }

        if (IdKelas == "" || IdKelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Kelas Kosong..!'
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

        if (IdPenilaian == "" || IdPenilaian == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Penilaian Kosong..!'
            })
            return;
        }

        if (Nilai == "" || Nilai == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nilai Kosong..!'
            })
            return;
        }

        if (!Nilai.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nilai tidak mengandung karakter angka..!'
            })
            return;
        }
        
        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), idPenilaian: parseInt(IdPenilaian), nilai: parseFloat(Nilai), deskripsi: Deskripsi };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "PenilaianSiswa/AddPenilaianSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Penilaian Siswa Berhasil Disimpan..!'
                    })
                    $('#TambahPenilaianSiswa').modal('hide');
                    GetDataPenilaianSiswa();
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

function UpdateDataPenilaianSiswa() {


    try {
      
        var IdTahunAjaran = document.getElementById("TahunAjaran1").value;
        var IdKelas = document.getElementById("NamaKelas1").value;
        var IdSiswa = document.getElementById("NamaSiswa1").value;
        var IdPenilaian = document.getElementById("NamaPenilaian1").value;
        var Nilai = document.getElementById("Nilai1").value;
        var Deskripsi = document.getElementById("Deskripsi1").value;

        var number = /^[0-9]+$/;

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
                text: 'Tahun Ajaran Kosong..!'
            })
            return;
        }

        if (IdKelas == "" || IdKelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Kelas Kosong..!'
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

        if (IdPenilaian == "" || IdPenilaian == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Penilaian Kosong..!'
            })
            return;
        }

        if (Nilai == "" || Nilai == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nilai Kosong..!'
            })
            return;
        }

        if (!Nilai.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nilai tidak mengandung karakter angka..!'
            })
            return;
        }

        var data = { id: parseInt(Id), idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), idPenilaian: parseInt(IdPenilaian), nilai: parseFloat(Nilai), deskripsi: Deskripsi };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "PenilaianSiswa/UpdatePenilaianSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Penilaian Siswa Berhasil Disimpan..!'
                    })
                    $('#EditPenilaianSiswa').modal('hide');
                    GetDataPenilaianSiswa();
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

function GetDataPenilaianSiswa() {

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

        $("#tabelPenilaianSiswa").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "PenilaianSiswa/PenilaianSiswaSearch",
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
                { 'data': 'namaPelajaran', "autoWidth": true },
                { 'data': 'namaPenilaian', "autoWidth": true },
                { 'data': 'nilai', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editPenilaianSiswa(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.idPenilaian + '\',\'' + row.namaPelajaran + '\',\'' + row.namaPenilaian + '\',\'' + row.nilai + '\',\'' + row.deskripsi + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editPenilaianSiswa(id, idTahunAjaran, tahunAjaran, idKelas, namaKelas, idSiswa, namaSiswa, idPenilaian, namaPelajaran, namaPenilaian, nilai, deskripsi) {
    Id = parseInt(id);
    document.getElementById("Id").value = id;
    document.getElementById("IdTahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("TahunAjaran1").value = tahunAjaran;
    document.getElementById("IdKelas1").value = idKelas.toString();
    document.getElementById("NamaKelas1").value = namaKelas;
    document.getElementById("IdSiswa1").value = idSiswa.toString();
    document.getElementById("NamaSiswa1").value = namaSiswa;
    document.getElementById("NamaPenilaian1").value = idPenilaian.toString();
    document.getElementById("Nilai1").value = nilai.toString();
    document.getElementById("Deskripsi1").value = deskripsi;

    $('#EditPenilaianSiswa').modal('show');
}

function GetSiswaAddData() {
    try {

        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
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

        var IdTahunAjaran = document.getElementById("TahunAjaran2").value;
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