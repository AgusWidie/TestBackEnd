var Id = 0

var TotalBayar = 0;
var NilaiUangBangunan = 0;
var TotalUangbangunanSiswa = 0;

var IdTahunAjaran;
var IdKelas;
var IdSiswa;

function onChangeBayar() {

    var IdTahunAjaran = document.getElementById("TahunAjaran").value;
    var IdSiswa = document.getElementById("NamaSiswa").value;
    GetUangBangunanAddData(IdTahunAjaran, IdSiswa);
}

function onChangeBayar1() {
    var IdTahunAjaran = document.getElementById("TahunAjaran1").value;
    var IdSiswa = document.getElementById("IdSiswa1").value;
    GetUangBangunanUpdateData(IdTahunAjaran, IdSiswa);
}

function SaveDataUangBangunan() {

    try {
        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var IdSiswa = document.getElementById("NamaSiswa").value;
        var NamaPembayaran = document.getElementById("NamaPembayaran").value;
        var Bayar = document.getElementById("Bayar").value;
        var SisaBayar = document.getElementById("SisaBayar").value;

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

        if (NamaPembayaran == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran Kosong..!'
            })
            return;
        }

        if (NamaPembayaran != "UangBangunan") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran tidak valid..!, Nama Pembayaran --> ' + NamaPembayaran
            })
            return;
        }

        if (NilaiUangBangunan == "" || NilaiUangBangunan == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Uang Bangunan Kosong..!'
            })
            return;
        }

        if (Bayar == "" || Bayar == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar Kosong..!'
            })
            return;
        }

        if (!Bayar.match(number)) {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar harus mengandung karakter angka..!'
            })
            return;
        }

        if (parseInt(Bayar) < 0) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar kurang dari 0..!'
            })
            return;
        }

        if (SisaBayar == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Sisa Bayar Kosong..!'
            })
            return;
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), namaPembayaran: NamaPembayaran, nilaiUangBangunan: parseInt(NilaiUangBangunan), bayar: parseInt(Bayar), totalBayar: parseInt(TotalBayar), sisaBayar: parseInt(SisaBayar) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "UangBangunan/AddUangBangunan",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Uang Bangunan Berhasil Disimpan..!'
                    })
                    $('#TambahUangBangunan').modal('hide');
                    GetDataUangBangunan();
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

function UpdateDataUangBangunan() {

    try {

        var IdTahunAjaran = document.getElementById("IdTahunAjaran1").value;
        var IdKelas = document.getElementById("IdKelas1").value;
        var IdSiswa = document.getElementById("IdSiswa1").value;
        var NamaPembayaran = document.getElementById("NamaPembayaran1").value;
        var Bayar = document.getElementById("Bayar1").value;
        var SisaBayar = document.getElementById("SisaBayar1").value;

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

        if (NamaPembayaran == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran Kosong..!'
            })
            return;
        }

        if (NamaPembayaran != "UangBangunan") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran tidak valid..!, Nama Pembayaran --> ' + NamaPembayaran
            })
            return;
        }

        if (NilaiUangBangunan == "" || NilaiUangBangunan == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Uang Bangunan Kosong..!'
            })
            return;
        }

        if (Bayar == "" || Bayar == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar Kosong..!'
            })
            return;
        }

        if (!Bayar.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar harus mengandung karakter angka..!'
            })
            return;
        }

        if (parseInt(Bayar) < 0) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar kurang dari 0..!'
            })
            return;
        }

        if (SisaBayar == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Sisa Bayar Kosong..!'
            })
            return;
        }

        var data = { id: parseInt(Id), idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), namaPembayaran: NamaPembayaran, nilaiUangBangunan: parseInt(NilaiUangBangunan), bayar: parseInt(Bayar), totalBayar: parseInt(TotalBayar), sisaBayar: parseInt(SisaBayar) };
        var stringData = JSON.stringify(data);


        $.ajax({

            type: "POST",
            url: "UangBangunan/UpdateUangBangunan",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Uang Bangunan Berhasil Disimpan..!'
                    })
                    $('#EditUangBangunan').modal('hide');
                    GetDataUangBangunan();
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

function GetTotalUangBangunanSiswaAddData(IdSiswa) {

    try {
        var data = { idSiswa: parseInt(IdSiswa) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "UangBangunan/TotalUangBangunan",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {
                //$.each(responseData, function (index, value) {

                //})

                if (responseData.error == false) {
                    document.getElementById("TotalBayar").value = responseData.data[0].toString();
                    TotalUangbangunanSiswa = parseInt(responseData.data[0].toString());

                    var Bayar = document.getElementById("Bayar").value;
                    if (Bayar == "") {
                        Bayar = "0";
                    }
                    TotalBayar = parseInt(Bayar) + parseInt(TotalUangbangunanSiswa);
                    var SisaBayar = 0;
                    if (TotalBayar <= NilaiUangBangunan) {
                        SisaBayar = NilaiUangBangunan - TotalBayar;
                    }
                    document.getElementById("TotalBayar").value = TotalBayar.toString();
                    document.getElementById("SisaBayar").value = SisaBayar.toString();


                } else {
                    document.getElementById("TotalBayar").value = "0";
                    TotalUangbangunanSiswa = 0;
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

function GetTotalUangBangunanSiswaUpdateData(IdSiswa) {

    try {
        var data = { idSiswa: parseInt(IdSiswa) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "UangBangunan/TotalUangBangunan",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {
                //$.each(responseData, function (index, value) {

                //})

                if (responseData.error == false) {
                    document.getElementById("TotalBayar1").value = responseData.data[0].toString();
                    TotalUangbangunanSiswa = parseInt(responseData.data[0].toString());

                    var Bayar = document.getElementById("Bayar1").value;
                    if (Bayar == "") {
                        Bayar = "0";
                    }
                    TotalBayar = parseInt(Bayar) + parseInt(TotalUangbangunanSiswa);
                    var SisaBayar = 0;
                    if (TotalBayar <= NilaiUangBangunan) {
                        SisaBayar = NilaiUangBangunan - TotalBayar;
                    }
                    document.getElementById("TotalBayar1").value = TotalBayar.toString();
                    document.getElementById("SisaBayar1").value = SisaBayar.toString();

                } else {
                    document.getElementById("TotalBayar1").value = "0";
                    TotalUangbangunanSiswa = 0;
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

function GetUangBangunanAddData(IdTahunAjaran, IdSiswa) {

    try {
        var data = { namaPembayaran: "Uang Bangunan", Kelas: 0, idTahunAjaran: parseInt(IdTahunAjaran) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "DataConfigPembayaran/DataConfigPembayaranByNama",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {
                //$.each(responseData, function (index, value) {

                //})

                if (responseData.error == false) {
                    document.getElementById("UangBangunan").value = responseData.data[2].toString();
                    NilaiUangBangunan = parseInt(responseData.data[2].toString());

                    GetTotalUangBangunanSiswaAddData(IdSiswa);
                } else {
                    document.getElementById("UangBangunan").value = "0";
                    NilaiUangBangunan = 0;
                    alert("Data Uang Bangunan Tidak Ada...!");
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

function GetUangBangunanUpdateData(IdTahunAjaran, IdSiswa) {

    try {
        var data = { namaPembayaran: "Uang Bangunan", Kelas: 0, idTahunAjaran: parseInt(IdTahunAjaran) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "DataConfigPembayaran/DataConfigPembayaranByNama",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (responseData) {
                //$.each(responseData, function (index, value) {

                //})

                if (responseData.error == false) {
                    document.getElementById("UangBangunan1").value = responseData.data[2].toString();
                    NilaiUangBangunan = parseInt(responseData.data[2].toString());

                    GetTotalUangBangunanSiswaUpdateData(IdSiswa);
                } else {
                    document.getElementById("UangBangunan1").value = "0";
                    NilaiUangBangunan = 0;
                    alert("Data Uang Bangunan Tidak Ada...!");
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

function GetDataUangBangunan() {

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

        $("#tabelUangBangunan").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "UangBangunan/UangBangunanSearch",
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
                { 'data': 'tanggalBuat', "autoWidth": true },
                { 'data': 'nilaiUangBangunan', "autoWidth": true },
                { 'data': 'bayar', "autoWidth": true },
                { 'data': 'totalBayar', "autoWidth": true },
                { 'data': 'sisaBayar', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editUangBangunan(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.nilaiUangBangunan + '\',\'' + row.bayar + '\',\'' + row.totalBayar + '\',\'' + row.sisaBayar + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editUangBangunan(id, idTahunAjaran, tahunAjaran, idKelas, namaKelas, idSiswa, namaSiswa, nilaiUangBangunan, bayar, totalBayar, sisaBayar) {
    Id = parseInt(id);

    document.getElementById("Id").value = id.toString();
    document.getElementById("IdTahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("TahunAjaran1").value = tahunAjaran;
    document.getElementById("IdKelas1").value = idKelas.toString();
    document.getElementById("NamaKelas1").value = namaKelas;
    document.getElementById("IdSiswa1").value = idSiswa.toString();
    document.getElementById("NamaSiswa1").value = namaSiswa;
    document.getElementById("NamaPembayaran1").value = "UangBangunan";
    document.getElementById("UangBangunan1").value = nilaiUangBangunan.toString();
    document.getElementById("Bayar1").value = bayar.toString();
    document.getElementById("SisaBayar1").value = sisaBayar.toString();

    $('#EditUangBangunan').modal('show');

    GetUangBangunanUpdateData(idTahunAjaran, idSiswa);


}

function GetSiswaAddData(IdTahunAjaran, IdKelas) {
    try {
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