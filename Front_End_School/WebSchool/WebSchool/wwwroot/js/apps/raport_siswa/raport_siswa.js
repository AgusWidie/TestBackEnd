var Id = 0;
var IdTahunAjaran;
var IdKelas;
var IdSiswa;

function SaveDataRaportSiswa() {

    try {

        var IdTahunAjaran = document.getElementById("TahunaAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var IdSiswa = document.getElementById("NamaSiswa").value;
        var IdPelajaran = document.getElementById("NamaPelajaran").value;
        var Nilai = document.getElementById("Nilai").value;
        var Keterangan = document.getElementById("Keterangan").value;

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

        if (IdPelajaran == "" || IdPelajaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pelajaran Kosong..!'
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
        
        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), idPelajaran: parseInt(IdPelajaran), nilai: parseFloat(Nilai), keterangan: Keterangan };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "RaportSiswa/AddRaportSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Penilaian Siswa Berhasil Disimpan..!'
                    })
                    $('#TambahRaportSiswa').modal('hide');
                    GetDataRaportSiswa();
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
        
        var IdTahunAjaran = document.getElementById("IdTahunAjaran1").value;
        var IdKelas = document.getElementById("IdKelas1").value;
        var IdSiswa = document.getElementById("IdSiswa1").value;
        var IdPelajaran = document.getElementById("NamaPelajaran1").value;
        var Nilai = document.getElementById("Nilai1").value;
        var Keterangan = document.getElementById("Keterangan1").value;

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

        if (IdPelajaran == "" || IdPelajaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pelajaran Kosong..!'
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

        var data = { id: parseInt(Id), idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), idPelajaran: parseInt(IdPelajaran), nilai: parseFloat(Nilai), keterangan: Keterangan };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "RaportSiswa/UpdateRaportSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Penilaian Siswa Berhasil Disimpan..!'
                    })
                    $('#EditRaportSiswa').modal('hide');
                    GetDataRaportSiswa();
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

function GetDataRaportSiswa() {

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

        $("#tabelRaportSiswa").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "RaportSiswa/RaportSiswaSearch",
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
                { 'data': 'nilai', "autoWidth": true },
                { 'data': 'keterangan', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editRaportSiswa(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.idPelajaran + '\',\'' + row.namaPelajaran + '\',\'' + row.nilai + '\',\'' + row.keterangan + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editRaportSiswa(id, idTahunAjaran, tahunAjaran, idKelas, namaKelas, idSiswa, namaSiswa, idPelajaran, namaPelajaran, nilai, keterangan) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("IdTahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("TahunAjaran1").value = tahunAjaran;
    document.getElementById("IdKelas1").value = idKelas.toString();
    document.getElementById("NamaKelas1").value = namaKelas;
    document.getElementById("IdSiswa1").value = idSiswa.toString();
    document.getElementById("NamaSiswa1").value = namaSiswa;
    document.getElementById("NamaPelajaran1").value = idPelajaran.toString();
    document.getElementById("Nilai1").value = nilai.toString();
    document.getElementById("Keterangan1").value = keterangan;

    $('#EditRaportSiswa').modal('show');
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