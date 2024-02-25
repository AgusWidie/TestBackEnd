var Id = 0;
var UangDaftarUlang = 0;
var Kembalian = 0;
var IdTahunAjaranTo;
var IdKeKelas;

function onChangeBayar() {
    Kembalian = 0;
    var Bayar = document.getElementById("Bayar").value;
    if (parseInt(Bayar) >= parseInt(UangDaftarUlang)) {
        Kembalian = parseInt(Bayar) - parseInt(UangDaftarUlang);
    } else {
        alert("Bayar kurang dari Daftar Ulang...!");
        Kembalian = 0;
    }
    document.getElementById("Kembalian").value = Kembalian.toString();
}

function onChangeBayar1() {
    Kembalian = 0;
    var Bayar = document.getElementById("Bayar1").value;
    if (parseInt(Bayar) >= parseInt(UangDaftarUlang)) {
        Kembalian = parseInt(Bayar) - parseInt(UangDaftarUlang);
    } else {
        alert("Bayar kurang dari Daftar Ulang...!");
        Kembalian = 0;
    }
    document.getElementById("Kembalian1").value = Kembalian.toString();
}

 function SaveDataDaftarUlang() {

    try {
        var IdTahunAjaran = document.getElementById("DariTahunaAjaran").value;
        var IdTahunAjaranTo = document.getElementById("KeTahunAjaran").value;
        var IdSiswa = document.getElementById("NamaSiswa").value;
        var IdDariKelas = document.getElementById("DariNamaKelas").value;
        var IdKeKelas = document.getElementById("KeNamaKelas").value;
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

        if (IdTahunAjaranTo == "" || IdTahunAjaranTo == "0") {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Ke Tahun Ajaran Kosong..!'
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

        if (IdDariKelas == "" || IdDariKelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas Kosong..!'
            })
            return;
        }

        if (IdKeKelas == "" || IdKeKelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Ke Kelas Kosong..!'
            })
            return;
        }

        const DariKelasArray = IdDariKelas.split('-');
        const KeKelasArray = IdKeKelas.split('-');
        IdDariKelas = DariKelasArray[0].toString();
        IdKeKelas = KeKelasArray[0].toString();
        var DariKelas = DariKelasArray[1].toString();
        var KeKelas = KeKelasArray[1].toString();
        Kembalian = 0;

        if (UangDaftarUlang == "" || UangDaftarUlang == "0") {
           
            Swal.fire({
                title: 'Informasi..!',
                text: 'Uang Daftar Ulang Kosong..!'
            })
            return;
        }

        if (!UangDaftarUlang.match(number)) {
         
            Swal.fire({
                title: 'Informasi..!',
                text: 'Uang Daftar Ulang harus mengandung karakter angka..!'
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

        if (NamaPembayaran != "UangDaftarUlang") {

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

        if (parseInt(Bayar) > parseInt(UangDaftarUlang)) {
            Kembalian = parseInt(Bayar) - parseInt(UangDaftarUlang);
        }

        if (parseInt(Bayar) < parseInt(UangDaftarUlang)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar kurang dari uang daftar ulang..!'
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


        var data = { idTahunAjaran: parseInt(idTahunAjaran), idTahunAjaranTo: parseInt(IdTahunAjaranTo), idSiswa: parseInt(IdSiswa), idDariKelas: parseInt(IdDariKelas), dariKelas: DariKelas, idKeKelas: parseInt(IdKeKelas), keKelas: parseInt(KeKelas), uangDaftarUlang: parseInt(UangDaftarUlang), bayar: parseInt(Bayar), kembalian: parseInt(Kembalian) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "DaftarUlang/AddDaftarUlang",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Daftar Ulang Berhasil Disimpan..!'
                    })
                    $('#TambahDaftarUlang').modal('hide');
                    GetDataDaftarUlang();
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

function UpdateDataDaftarUlang() {

    try {
        var IdTahunAjaran = document.getElementById("DariTahunaAjaran1").value;
        var IdTahunAjaranTo = document.getElementById("KeTahunAjaran1").value;
        var IdSiswa = document.getElementById("NamaSiswa1").value;
        var IdDariKelas = document.getElementById("DariNamaKelas1").value;
        var IdKeKelas = document.getElementById("KeNamaKelas1").value;
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

        if (IdTahunAjaranTo == "" || IdTahunAjaranTo == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Ke Tahun Ajaran Kosong..!'
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

        if (IdDariKelas == "" || IdDariKelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kelas Kosong..!'
            })
            return;
        }

        if (IdKeKelas == "" || IdKeKelas == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Ke Kelas Kosong..!'
            })
            return;
        }


        const DariKelasArray = IdDariKelas.split('-');
        const KeKelasArray = IdKeKelas.split('-');
        IdDariKelas = DariKelasArray[0].toString();
        IdKeKelas = KeKelasArray[0].toString();
        var DariKelas = DariKelasArray[1].toString();
        var KeKelas = KeKelasArray[1].toString();
        Kembalian = 0;

        if (UangDaftarUlang == "" || UangDaftarUlang == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Uang Daftar Ulang Kosong..!'
            })
            return;
        }

        if (!UangDaftarUlang.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Uang Daftar Ulang harus mengandung karakter angka..!'
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

        if (NamaPembayaran != "UangDaftarUlang") {

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

        if (parseInt(Bayar) > parseInt(UangDaftarUlang)) {
            Kembalian = parseInt(Bayar) - parseInt(UangDaftarUlang);
        }

        if (parseInt(Bayar) < parseInt(UangDaftarUlang)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar kurang dari uang daftar ulang..!'
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


        var data = { id: parseInt(Id), idTahunAjaran: parseInt(idTahunAjaran), idTahunAjaranTo: parseInt(IdTahunAjaranTo), idSiswa: parseInt(IdSiswa), idDariKelas: parseInt(IdDariKelas), dariKelas: DariKelas, idKeKelas: parseInt(IdKeKelas), keKelas: KeKelas, uangDaftarUlang: parseInt(UangDaftarUlang), bayar: parseInt(Bayar), kembalian: parseInt(Kembalian) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "DaftarUlang/UpdateDaftarUlang",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Daftar Ulang Berhasil Disimpan..!'
                    })
                    $('#EditDaftarUlang').modal('hide');
                    GetDataDaftarUlang();
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

function GetDataDaftarUlang() {

    try {

        IdTahunAjaranTo = document.getElementById("TahunAjaran2").value;
        IdKeKelas = document.getElementById("NamaKelas2").value;

        if (IdTahunAjaranTo == "" || IdTahunAjaranTo == null) {
            IdTahunAjaranTo = "0";
        }

        if (IdKeKelas == "" || IdKeKelas == null) {
            IdKeKelas = "0";
        }

        var data = { idTahunAjaranTo: parseInt(IdTahunAjaranTo), idKeKelas: parseInt(IdKeKelas) };
        var stringData = JSON.stringify(data);

        $("#tabelDaftarUlang").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "DaftarUlang/DaftarUlangSearch",
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
                { 'data': 'nilaiDaftarUlang', "autoWidth": true },
                { 'data': 'bayar', "autoWidth": true },
                { 'data': 'deskripsi', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editDaftarUlang(\'' + row.id + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idTahunAjaranTo + '\',\'' + row.tahunAjaranTo + '\',\'' + row.idDariKelas + '\',\'' + row.dariKelas + '\',\'' + row.namaDariKelas + '\',\'' + row.idKeKelas + '\',\'' + row.keKelas + '\',\'' + row.namaKeKelas + '\',\'' + row.nilaiDaftarUlang + '\',\'' + row.bayar + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editDaftarUlang(id, idSiswa, namaSiswa, idTahunAjaran, tahunAjaran, idTahunAjaranTo, tahunAjaranTo, idDariKelas, dariKelas, namaDariKelas, idKeKelas, keKelas, namaKeKelas, nilaiDaftarUlang, bayar) {
    Id = parseInt(id);
    document.getElementById("Id").value = id.toString();
    document.getElementById("IdDariTahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("DariTahunAjaran1").value = tahunAjaran;
    document.getElementById("IdDariNamaKelas1").value = idDariKelas.toString();
    document.getElementById("DariNamaKelas1").value = namaDariKelas;
    document.getElementById("IdSiswa1").value = idSiswa.toString();
    document.getElementById("NamaSiswa1").value = namaSiswa;
    document.getElementById("KeTahunAjaran1").value = idTahunAjaranTo.toString();
    document.getElementById("KeNamaKelas1").value = idKeKelas.toString();
    document.getElementById("NamaPembayaran1").value = "Daftar Ulang";
    document.getElementById("Bayar1").value = bayar.toString();
    var Kembalian1 = parseInt(bayar) - parseInt(nilaiDaftarUlang);
    document.getElementById("Kembalian1").value = Kembalian1.toString();

    $('#EditDaftarUlang').modal('show');
}

function GetDaftarUlangAddData(IdTahunAjaran, Kelas) {

    try {
        var data = { namaPembayaran: "Daftar Ulang", kelas: parseInt(Kelas), idTahunAjaran: parseInt(IdTahunAjaran) };
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
                    document.getElementById("UangDaftarUlang").value = responseData.data[2].toString();
                    UangDaftarUlang = parseInt(responseData.data[2].toString());
                } else {
                    document.getElementById("UangDaftarUlang").value = "0";
                    UangDaftarUlang = 0;
                    alert("Data Uang Daftar Ulang Tidak Ada...!");
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


function GetDaftarUlangUpdateData(IdTahunAjaran, Kelas) {
    try {
        var data = { namaPembayaran: "Daftar Ulang", kelas: parseInt(Kelas), idTahunAjaran: parseInt(IdTahunAjaran) };
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
                    document.getElementById("UangDaftarUlang1").value = responseData.data[2].toString();
                    UangDaftarUlang = parseInt(responseData.data[2].toString());
                } else {
                    document.getElementById("UangDaftarUlang1").value = "0";
                    UangDaftarUlang = 0;
                    alert("Data Uang Daftar Ulang Tidak Ada...!");
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



