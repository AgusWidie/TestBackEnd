var Id = 0;

var NilaiSPP = 0;
var Kembalian = 0;

var IdTahunAjaran;
var IdKelas;
var Tahun;
var NamaBulan;

function onChangeBayar() {
    Kembalian = 0;
    var Bayar = document.getElementById("Bayar").value;
    if (parseInt(Bayar) >= parseInt(NilaiSPP)) {
        Kembalian = parseInt(Bayar) - parseInt(NilaiSPP);
    } else {
        alert("Bayar kurang dari Uang SPP...!");
        Kembalian = 0;
    }
    document.getElementById("Kembalian").value = Kembalian.toString();
}

function onChangeBayar1() {
    Kembalian = 0;
    var Bayar = document.getElementById("Bayar1").value;
    if (parseInt(Bayar) >= parseInt(NilaiSPP)) {
        Kembalian = parseInt(Bayar) - parseInt(NilaiSPP);
    } else {
        alert("Bayar kurang dari Uang SPP...!");
        Kembalian = 0;
    }
    document.getElementById("Kembalian1").value = Kembalian.toString();
}

function SaveDataUangSPP() {

    try {
        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var IdSiswa = document.getElementById("NamaSiswa").value;
        var Tahun = document.getElementById("Tahun").value;
        var Bulan = document.getElementById("Bulan").value;
        var NamaPembayaran = document.getElementById("NamaPembayaran").value;
        var Bayar = document.getElementById("Bayar").value;

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

        if (Tahun == "" || Tahun == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Kosong..!'
            })
            return;
        }

        if (Tahunlength < 4) {
            
            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun kurang dari 4 karakter..!'
            })
            return;

        }

        if (Tahunlength > 4) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun lebih dari 4 karakter..!'
            })
            return;

        }

        if (!Tahun.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun tidak mengandung karakter angka..!'
            })
            return;
        }

        if (Bulan == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bulan Kosong..!'
            })
            return;
        }

        if (Bulan != "Januari" && Bulan != "Februari" && Bulan != "Maret" && Bulan != "April" && Bulan != "Mei" && Bulan != "Juni" && Bulan != "Juli"
            && Bulan != "Agustus" && Bulan != "September" && Bulan != "Oktober" && Bulan != "November" && Bulan != "Desember") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Input bulan tidak valid..! -- > ' + Bulan
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

        if (NamaPembayaran != "SPP") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran tidak valid..!, Nama Pembayaran --> ' + NamaPembayaran
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


        if (parseInt(Bayar) < parseInt(NilaiSPP)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar kurang dari Uang SPP..!'
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


        if (parseInt(Bayar) > parseInt(NilaiSPP)) {
            Kembalian = parseInt(Bayar) - parseInt(NilaiSPP);
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), tahun: parseInt(Tahun), bulan: Bulan, namaPembayaran: NamaPembayaran, nilaiSpp: parseInt(NilaiSPP), bayar: parseInt(Bayar), kembalian: parseInt(Kembalian) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "SPP/AddSPP",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Uang SPP Berhasil Disimpan..!'
                    })
                    $('#TambahUangSPP').modal('hide');
                    GetDataSPP();
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

function UpdateDataUangSPP() {

    try {

        var IdTahunAjaran = document.getElementById("IdTahunAjaran1").value;
        var IdKelas = document.getElementById("IdKelas1").value;
        var IdSiswa = document.getElementById("IdSiswa1").value;
        var Tahun = document.getElementById("Tahun1").value;
        var Bulan = document.getElementById("Bulan1").value;
        var NamaPembayaran = document.getElementById("NamaPembayaran1").value;
        var Bayar = document.getElementById("Bayar1").value;

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

        if (Tahun == "" || Tahun == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun Kosong..!'
            })
            return;
        }

        if (Tahunlength < 4) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun kurang dari 4 karakter..!'
            })
            return;

        }

        if (Tahunlength > 4) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun lebih dari 4 karakter..!'
            })
            return;

        }

        if (!Tahun.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Tahun tidak mengandung karakter angka..!'
            })
            return;
        }

        if (Bulan == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bulan Kosong..!'
            })
            return;
        }

        if (Bulan != "Januari" && Bulan != "Februari" && Bulan != "Maret" && Bulan != "April" && Bulan != "Mei" && Bulan != "Juni" && Bulan != "Juli"
            && Bulan != "Agustus" && Bulan != "September" && Bulan != "Oktober" && Bulan != "November" && Bulan != "Desember") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Input bulan tidak valid..! -- > ' + Bulan
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

        if (NamaPembayaran != "SPP") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pembayaran tidak valid..!, Nama Pembayaran --> ' + NamaPembayaran
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

        if (parseInt(Bayar) < parseInt(NilaiSPP)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar kurang dari Uang SPP..!'
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

        if (parseInt(Bayar) > parseInt(NilaiSPP)) {
            Kembalian = parseInt(Bayar) - parseInt(NilaiSPP);
        }

        var data = { id: parseInt(Id), idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), tahun: parseInt(Tahun), bulan: Bulan, namaPembayaran: NamaPembayaran, nilaiSpp: parseInt(NilaiSPP), bayar: parseInt(Bayar), kembalian: parseInt(Kembalian) };
        var stringData = JSON.stringify(data);


        $.ajax({

            type: "POST",
            url: "SPP/UpdateSPP",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Uang SPP Berhasil Disimpan..!'
                    })
                    $('#EditUangSPP').modal('hide');
                    GetDataSPP();
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

function GetDataSPP() {

    try {

        IdTahunAjaran = document.getElementById("TahunAjaran2").value;
        IdKelas = document.getElementById("NamaKelas2").value;
        Tahun = document.getElementById("Tahun2").value;
        NamaBulan = document.getElementById("NamaBulan2").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == null) {
            IdTahunAjaran = "0";
        }

        if (IdKelas == "" || IdKelas == null) {
            IdKelas = "0";
        }

        if (Tahun == "" || Tahun == null) {
            Tahun = "0";
        }

        if (NamaBulan == "" || NamaBulan == null) {
            NamaBulan = "";
        }

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), tahun: parseInt(Tahun), namaBulan: NamaBulan };
        var stringData = JSON.stringify(data);

        $("#tabelSPP").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "SPP/SPPSearch",
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
                { 'data': 'tahun', "autoWidth": true },
                { 'data': 'namaBulan', "autoWidth": true },
                { 'data': 'nilaiSpp', "autoWidth": true },
                { 'data': 'bayar', "autoWidth": true },
                { 'data': 'tangalBuat', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editSPP(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.kelas + '\',\'' + row.namaKelas + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.tahun + '\',\'' + row.bulan + '\',\'' + row.namaBulan + '\',\'' + row.nilaiSpp + '\',\'' + row.bayar + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editSPP(id, idTahunAjaran, tahunAjaran, idKelas, kelas, namaKelas, idSiswa, namaSiswa, tahun, bulan, namaBulan, nilaiSpp, bayar) {

    Id = parsInt(id);

    document.getElementById("Id").value = id.toString();
    document.getElementById("IdTahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("TahunaAjaran1").value = tahunAjaran;
    document.getElementById("IdKelas1").value = idKelas.toString();
    document.getElementById("NamaKelas1").value = namaKelas;
    document.getElementById("IdSiswa1").value = idSiswa.toString();
    document.getElementById("NamaSiswa1").value = namaSiswa;
    document.getElementById("Tahun1").value = tahun.toString();
    document.getElementById("Bulan1").value = namaBulan;
    document.getElementById("Bayar1").value = bayar.toString();

    $('#EditUangSPP').modal('show');

    GetUangSPPUpdateData(parseInt(idTahunAjaran), parseInt(kelas));
}

function GetUangSPPAddData(IdTahunAjaran, Kelas) {

    try {
        var data = { namaPembayaran: "SPP", kelas: parseInt(Kelas), idTahunAjaran: parseInt(IdTahunAjaran) };
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
                    document.getElementById("UangSPP").value = responseData.data[2].toString();
                    NilaiSPP = parseInt(responseData.data[2].toString());
                } else {
                    document.getElementById("UangSPP").value = "0";
                    NilaiSPP = 0;
                    alert("Data Uang SPP Tidak Ada...!");
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

function GetUangSPPUpdateData(IdTahunAjaran, Kelas) {

    try {
        var data = { namaPembayaran: "SPP", kelas: parseInt(Kelas), idTahunAjaran: parseInt(IdTahunAjaran) };
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
                    document.getElementById("UangSPP1").value = responseData.data[2].toString();
                    NilaiSPP = parseInt(responseData.data[2].toString());
                } else {
                    document.getElementById("UangSPP1").value = "0";
                    NilaiSPP = 0;
                    alert("Data Uang SPP Tidak Ada...!");
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
