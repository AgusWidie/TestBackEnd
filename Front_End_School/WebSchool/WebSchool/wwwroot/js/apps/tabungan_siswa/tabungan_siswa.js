var Id = 0;
var IdTahunAjaran;
var IdKelas;
var IdSiswa;

function SaveDataTabunganSiswa() {

    try {

        var IdTahunAjaran = document.getElementById("TahunAjaran").value;
        var IdKelas = document.getElementById("NamaKelas").value;
        var IdSiswa = document.getElementById("NamaSiswa").value;
        var Debit = document.getElementById("Debit").value;
        var TotalDebit = document.getElementById("TotalDebit").value;
        var Credit = document.getElementById("Kredit").value;
        var TotalKredit = document.getElementById("TotalKredit").value;

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

        if (Debit == "" && Credit == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Debit dan Credit Kosong..!'
            })
            return;
        }


        if (Debit == "0" && Credit == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Debit dan Kredit Kosong..!'
            })
            return;
        }


        if (!Debit.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Debit tidak mengandung karakter angka..!'
            })
            return;
        }

        if (!Credit.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kredit tidak mengandung karakter angka..!'
            })
            return;
        }

        if (parseInt(TotalDebit) > parseInt(TotalKredit)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Saldo yang di ambil tidak mencukupi..!'
            })
            return;
        }
        
        var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), debit: parseInt(Debit), credit: parseInt(Credit) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "TabunganSiswa/AddTabunganSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Tabungan Siswa Berhasil Disimpan..!'
                    })
                    $('#TambahTabunganSiswa').modal('hide');
                    GetDataTabunganSiswa();
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

function UpdateDataTabunganSiswa() {


    try {

        var IdTahunAjaran = document.getElementById("IdTahunAjaran1").value;
        var IdKelas = document.getElementById("IdKelas1").value;
        var IdSiswa = document.getElementById("IdSiswa1").value;
        var Debit = document.getElementById("Debit1").value;
        var TotalDebit = document.getElementById("TotalDebit1").value;
        var Credit = document.getElementById("Kredit1").value;
        var TotalKredit = document.getElementById("TotalKredit1").value;

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

        if (Debit == "" && Credit == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Debit dan Credit Kosong..!'
            })
            return;
        }


        if (Debit == "0" && Credit == "0") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Debit dan Credit Kosong..!'
            })
            return;
        }


        if (!Debit.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Debit tidak mengandung karakter angka..!'
            })
            return;
        }

        if (!Credit.match(number)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Kredit tidak mengandung karakter angka..!'
            })
            return;
        }

        if (parseInt(TotalDebit) > parseInt(TotalKredit)) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Saldo yang di ambil tidak mencukupi..!'
            })
            return;
        }

        var data = { id: parseInt(Id), idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa), debit: parseInt(Debit), credit: parseInt(Credit) };
        var stringData = JSON.stringify(data);

        $.ajax({

            type: "POST",
            url: "TabunganSiswa/UpdateTabunganSiswa",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {

                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Data Tabungan Siswa Berhasil Disimpan..!'
                    })
                    $('#EditTabunganSiswa').modal('hide');
                    GetDataTabunganSiswa();
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

function GetDataTabunganSiswa() {

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

        $("#tabelTabunganSiswa").DataTable({

            "destroy": true,
            "paging": true,
            "searching": true,
            "filter": true,
            "font-size": "14px",
            "cache": false,
            "ajax": {
                "url": "TabunganSiswa/TabunganSiswaSearch",
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
                { 'data': 'debit', "autoWidth": true },
                { 'data': 'credit', "autoWidth": true },
                {
                    "render": function (data, type, row) {
                        return '<button type="button" class="btn btn-warning" style="font-size:14px;" onclick="editTabunganSiswa(\'' + row.id + '\',\'' + row.idTahunAjaran + '\',\'' + row.tahunAjaran + '\',\'' + row.idKelas + '\',\'' + row.namaKelas + '\',\'' + row.idSiswa + '\',\'' + row.namaSiswa + '\',\'' + row.debit + '\',\'' + row.credit + '\');">Edit</button>';
                    }
                },

            ]
        });


    }
    catch (err) {
        alert(err.toString());
    }
} 

function editTabunganSiswa(id, idTahunAjaran, tahunAjaran, idKelas, namaKelas, idSiswa, namaSiswa, debit, credit) {
    Id = parseInt(id);

    document.getElementById("Id").value = id.toString();
    document.getElementById("IdTahunAjaran1").value = idTahunAjaran.toString();
    document.getElementById("TahunAjaran1").value = tahunAjaran;
    document.getElementById("IdKelas1").value = idKelas.toString();
    document.getElementById("NamaKelas1").value = namaKelas;
    document.getElementById("IdSiswa1").value = idSiswa.toString();
    document.getElementById("NamaSiswa1").value = namaSiswa;
    document.getElementById("Debit1").value = debit.toString();
    document.getElementById("Credit1").value = credit.toString();

    $('#EditTabunganSiswa').modal('show');
}

function GetTotalTabunganSiwaAdd(IdTahunAjaran, IdKelas, IdSiswa) {

    var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa) };
    var stringData = JSON.stringify(data);
    var Debit = "0";
    var Credit = "0";

    var TotalDebit = 0;
    var TotalCredit = 0;

    $.ajax({

        type: "POST",
        url: "TabunganSiswa/TotalTabunganSiswa",
        data: stringData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (responseData) {

            if (responseData.error == false) {
                document.getElementById("TotalDebit").value = responseData.data[0].toString();
                document.getElementById("TotalKredit").value = responseData.data[1].toString();

                if (document.getElementById("Debit").value != "") {
                    Debit = document.getElementById("Debit").value;
                    TotalDebit = parseInt(Debit) + parseInt(responseData.data[0].toString());

                    document.getElementById("TotalDebit").value = TotalDebit.toString();
                }

                if (document.getElementById("Kredit").value != "") {
                    Credit = document.getElementById("Kredit").value;
                    TotalCredit = parseInt(Credit) + parseInt(responseData.data[1].toString());

                    document.getElementById("TotalKredit").value = TotalCredit.toString();
                }
            } else {
                document.getElementById("TotalDebit").value = "0";
                document.getElementById("TotalKredit").value = "0";
            }
        },
        error: function (error) {

        }
    });
}

function GetTotalTabunganSiwaUpdate(IdTahunAjaran, IdKelas, IdSiswa) {

    var data = { idTahunAjaran: parseInt(IdTahunAjaran), idKelas: parseInt(IdKelas), idSiswa: parseInt(IdSiswa) };
    var stringData = JSON.stringify(data);

    var Debit = "0";
    var Credit = "0";

    var TotalDebit = 0;
    var TotalCredit = 0;

    $.ajax({

        type: "POST",
        url: "TabunganSiswa/TotalTabunganSiswa",
        data: stringData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (responseData) {

            if (responseData.error == false) {
                document.getElementById("TotalDebit1").value = responseData.data[0].toString();
                document.getElementById("TotalKredit1").value = responseData.data[1].toString();

                if (document.getElementById("Debit1").value != "") {
                    Debit = document.getElementById("Debit1").value;
                    TotalDebit = parseInt(Debit) + parseInt(responseData.data[0].toString());

                    document.getElementById("TotalDebit1").value = TotalDebit.toString();
                }

                if (document.getElementById("Kredit1").value != "") {
                    Credit = document.getElementById("Kredit1").value;
                    TotalCredit = parseInt(Credit) + parseInt(responseData.data[1].toString());

                    document.getElementById("TotalKredit1").value = TotalCredit.toString();
                }

            } else {
                document.getElementById("TotalDebit1").value = "0";
                document.getElementById("TotalKredit1").value = "0";
            }
        },
        error: function (error) {

        }
    });
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