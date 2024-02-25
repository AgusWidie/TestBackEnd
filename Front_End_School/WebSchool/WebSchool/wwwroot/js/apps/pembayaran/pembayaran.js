var Id = 0;

var NilaiPembayaran = 0;
var Kembalian = 0;

var IdTahunAjaran;
var Kelas;
var IdSiswa;


function onChangeIdConfigPembayaran() {
    var NamaPembayaran = document.getElementById("NamaPembayaran").value;
    const dataSplit = NamaPembayaran.split("-");
    var IdConfigPembayaran = dataSplit[0].toString();
    document.getElementById("IdConfigPembayaran").value = IdConfigPembayaran;
}


function onChangeBayar() {
    Kembalian = 0;
    var Bayar = document.getElementById("Bayar").value;
    if (parseInt(Bayar) >= parseInt(NilaiPembayaran)) {
        Kembalian = parseInt(Bayar) - parseInt(NilaiPembayaran);
    } else {
        alert("Bayar kurang dari Uang Pembayaran...!");
        Kembalian = 0;
    }
    document.getElementById("Kembalian").value = Kembalian.toString();
}

function onChangeBayar1() {
    Kembalian = 0;
    var Bayar = document.getElementById("Bayar1").value;
    if (parseInt(Bayar) >= parseInt(NilaiPembayaran)) {
        Kembalian = parseInt(Bayar) - parseInt(NilaiPembayaran);
    } else {
        alert("Bayar kurang dari Uang Pembayaran...!");
        Kembalian = 0;
    }
    document.getElementById("Kembalian1").value = Kembalian.toString();
}

function SaveDataUangPembayaran() {

    try {
        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var IdSiswa = document.getElementById("NamaSiswa").value;
        var IdConfigPembayaran = document.getElementById("IdConfigPembayaran").value;
        var Bayar = document.getElementById("Bayar").value;
        var Kembalian = document.getElementById("Kembalian").value;

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

        if (IdConfigPembayaran == "" || IdConfigPembayaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Pembayaran Kosong..!'
            })
            return;
        }

        if (!NilaiPembayaran.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Uang Pembayaran tidak mengandung angka..!'
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


        if (parseInt(Bayar) < parseInt(NilaiPembayaran)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar kurang dari Uang Pembayaran..!'
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


        if (parseInt(Bayar) > parseInt(NilaiPembayaran)) {
            Kembalian = parseInt(Bayar) - parseInt(NilaiPembayaran);
        }

        var data = { idSiswa: parseInt(IdSiswa), idConfigPembayaran: parseInt(IdConfigPembayaran), nilaiPembayaran: parseInt(NilaiPembayaran), bayar: parseInt(Bayar), kembalian: parseInt(Kembalian) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "Pembayaran/AddPembayaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pembayaran Berhasil Disimpan..!'
                    })
                    $('#TambahUangPembayaran').modal('hide');
                    GetDataPembayaran();
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

function UpdateDataUangPembayaran() {

    try {

        var IdTahunAjaran = document.getElementById("IdTahunAjaran1").value;
        var IdKelas = document.getElementById("IdKelas1").value;
        var IdSiswa = document.getElementById("IdSiswa1").value;
        var IdConfigPembayaran = document.getElementById("IdConfigPembayaran1").value;
        var Bayar = document.getElementById("Bayar1").value;
        var Kembalian = document.getElementById("Kembalian1").value;

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

        if (IdConfigPembayaran == "" || IdConfigPembayaran == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Id Pembayaran Kosong..!'
            })
            return;
        }

        if (!NilaiPembayaran.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Uang Pembayaran tidak mengandung angka..!'
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


        if (parseInt(Bayar) < parseInt(NilaiPembayaran)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Bayar kurang dari Uang Pembayaran..!'
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


        if (parseInt(Bayar) > parseInt(NilaiPembayaran)) {
            Kembalian = parseInt(Bayar) - parseInt(NilaiPembayaran);
        }

        var data = { id: parseInt(Id), idSiswa: parseInt(IdSiswa), idConfigPembayaran: parseInt(IdConfigPembayaran), nilaiPembayaran: parseInt(NilaiPembayaran), bayar: parseInt(Bayar), kembalian: parseInt(Kembalian) };
        var stringData = JSON.stringify(data);


        $.ajax({

            type: "POST",
            url: "Pembayaran/UpdatePembayaran",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Pembayaran Berhasil Disimpan..!'
                    })
                    $('#EditUangPembayaran').modal('hide');
                    GetDataPembayaran();
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

function GetDataPembayaran() {

    try {

        IdTahunAjaran = document.getElementById("TahunAjaran2").value;
        IdKelas = document.getElementById("NamaKelas2").value;
        IdSiswa = document.getElementById("NamaSiswa2").value;

        if (IdTahunAjaran == "" || IdTahunAjaran == null) {
            IdTahunAjaran = "0";
        }

        if (IdKelas == "" || IdKelas == null) {
            IdKelas = "0-0";
        }

        if (IdSiswa == "" || IdSiswa == null) {
            IdSiswa = "0";
        }

        const dataKelas = IdKelas.split('-');
        var Kelas = dataKelas[1].toString();

        var data = { idTahunAjaran: parseInt(IdTahunAjaran), kelas: parseInt(Kelas), idSiswa: parseInt(IdSiswa) };
        var stringData = JSON.stringify(data);

        $("#tabelPembayaran").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "Pembayaran/PembayaranSearch",
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
                { 'data': 'namaPembayaran', "autoWidth": true },
                { 'data': 'nilaiPembayaran', "autoWidth": true },
                { 'data': 'bayar', "autoWidth": true },
                { 'data': 'kembalian', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editPembayaran(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.kelas + '\',\'' + row.namaKelas + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.idConfigPembayaran + '\',\'' + row.namaPembayaran + '\',\'' + row.nilaiPembayaran + '\',\'' + row.bayar + '\',\'' + row.kembalian + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editPembayaran(id, idTahunAjaran, tahunAjaran, idKelas, kelas, namaKelas, idSiswa, namaSiswa, idConfigPembayaran, namaPembayaran, nilaiPembayaran, bayar, kembalian) {

    Id = parsInt(id);

    document.getElementById("Id").value = id.toString();
    document.getElementById("IdTahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("TahunAjaran1").value = tahunAjaran;
    document.getElementById("IdKelas1").value = idKelas.toString();
    document.getElementById("NamaKelas1").value = namaKelas.toString();
    document.getElementById("IdSiswa1").value = idSiswa.toString();
    document.getElementById("NamaSiswa1").value = namaSiswa;
    document.getElementById("IdConfigPembayaran1").value = idConfigPembayaran.toString();
    document.getElementById("NamaPembayaran1").value = namaPembayaran;
    document.getElementById("UangPembayaran1").value = nilaiPembayaran;
    document.getElementById("Bayar1").value = bayar.toString();
    document.getElementById("Kembalian1").value = kembalian.toString();
    $('#EditUangPembayaran').modal('show');

    GetUangPembayaranUpdateData(namaPembayaran, parseInt(idTahunAjaran), parseInt(kelas));
}

function GetUangPembayaranAddData(NamaPembayaran, IdTahunAjaran, Kelas) {

    try {
        var data = { namaPembayaran: NamaPembayaran, idTahunAjaran: parseInt(IdTahunAjaran), kelas: parseInt(Kelas) };
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
                    document.getElementById("UangPembayaran").value = responseData.data[2].toString();
                    NilaiPembayaran = parseInt(responseData.data[2].toString());
                } else {
                    document.getElementById("UangPembayaran").value = "0";
                    NilaiPembayaran = 0;
                    alert("Data Uang Pembayaran Tidak Ada...!");
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

function GetUangPembayaranUpdateData(NamaPembayaran, IdTahunAjaran, Kelas) {

    try {
        var data = { namaPembayaran: NamaPembayaran, idTahunAjaran: parseInt(IdTahunAjaran), kelas: parseInt(Kelas) };
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
                    document.getElementById("UangPembayaran1").value = responseData.data[2].toString();
                    NilaiPembayaran = parseInt(responseData.data[2].toString());
                } else {
                    document.getElementById("UangPembayaran1").value = "0";
                    NilaiPembayaran = 0;
                    alert("Data Uang Pembayaran Tidak Ada...!");
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
        var IdKelasData = document.getElementById("NamaKelas").value;

        const dataKelas = IdKelasData.split('-');
        var IdKelas = dataKelas[0].toString();

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
        var IdKelasData = document.getElementById("NamaKelas2").value;

        const dataKelas = IdKelasData.split('-');
        var IdKelas = dataKelas[0].toString();

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
