function SaveDataMenuRole() {

    var IdPeran = document.getElementById("NamaPeran").value;
    var IdMenu = document.getElementById("NamaMenu").value;

    if (IdPeran == "" || IdPeran == "0") {

        Swal.fire({
            title: 'Informasi..!',
            text: 'Id Peran Kosong..!'
        })
        return;
    }

    if (IdMenu == "" || IdMenu == "0") {

        Swal.fire({
            title: 'Informasi..!',
            text: 'Id Menu Kosong..!'
        })
        return;
    }

    var data = { idPeran: parseInt(IdPeran), idMenu: parseInt(IdMenu) };
    var stringData = JSON.stringify(data);

    $.ajax({

        type: "POST",
        url: "MenuRole/AddMenuRole",
        data: stringData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.success == true) {
               
                Swal.fire({
                    title: 'Informasi..!',
                    text: 'Data Peran Menu Berhasil Disimpan..!'
                })
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

function UpdateDataMenuRole() {

    var Id = document.getElementById("Id").value;
    var IdPeran = document.getElementById("NamaPeran1").value;
    var IdMenu = document.getElementById("NamaMenu1").value;

    if (Id == "" || Id == "0") {
       
        Swal.fire({
            title: 'Informasi..!',
            text: 'Id Kosong..!'
        })
        return;
    }

    if (IdPeran == "" || IdPeran == "0") {

        Swal.fire({
            title: 'Informasi..!',
            text: 'Id Peran Kosong..!'
        })
        return;
    }

    if (IdMenu == "" || IdMenu == "0") {
       
        Swal.fire({
            title: 'Informasi..!',
            text: 'Id Menu Kosong..!'
        })
        return;
    }

    var data = { id: parseInt(Id), idPeran: parseInt(IdPeran), idMenu: parseInt(IdMenu) };
    var stringData = JSON.stringify(data);

    $.ajax({

        type: "POST",
        url: "MenuRole/UpdateMenuRole",
        data: stringData,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data.success == true) {

                Swal.fire({
                    title: 'Informasi..!',
                    text: 'Data Peran Menu Berhasil Disimpan..!'
                })
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

