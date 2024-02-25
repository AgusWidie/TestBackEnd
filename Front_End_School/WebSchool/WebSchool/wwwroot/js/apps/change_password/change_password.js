
function SavePassword() {

    try {
        var NamaPengguna = document.getElementById("NamaPengguna").value;
        var PasswordLama = document.getElementById("PasswordLama").value;
        var PasswordBaru = document.getElementById("PasswordBaru").value;
        var resultPassword = "";

        if (NamaPengguna == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Nama Pengguna Kosong..!'
            })
            return;

        }

        if (PasswordLama == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password Lama Kosong..!'
            })
            return;

        }

        if (PasswordLama.length < 8) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password Lama minimal harus 8 karakter..!'
            })
            return;
        }

        if (PasswordLama.length > 15) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password Lama tidak boleh lebih dari 15 karakter..!'
            })
            return;
        }

        resultPassword = checkPasswordValidation(PasswordLama);

        if (resultPassword != "Success") {
            alert(resultPassword.toString());
            return;
        }

        if (PasswordBaru == "") {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password Baru Kosong..!'
            })
            return;

        }

        if (PasswordBaru.length < 8) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password Baru minimal harus 8 karakter..!'
            })
            return;
        }

        if (PasswordBaru.length > 15) {

            Swal.fire({
                title: 'Informasi..!',
                text: 'Password Baru tidak boleh lebih dari 15 karakter..!'
            })
            return;
        }

        resultPassword = checkPasswordValidation(PasswordBaru); 

        if (resultPassword != "Success") {
            alert(resultPassword.toString());
            return;
        }


        var data = { namaPengguna: NamaPengguna, passwordLama: PasswordLama, passwordBaru: PasswordBaru };
        var stringData = JSON.stringify(data);
        //console.log("stringData : " + stringData);

        $.ajax({

            type: "POST",
            url: "ChangePassword/GantiPassword",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.success == true) {
                
                    Swal.fire({
                        title: 'Informasi..!',
                        text: 'Ganti Password Berhasil Disimpan..!'
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
    catch (err) {
        alert(err.toString());
    }
    
}

function checkPasswordValidation(value) {
    const isWhitespace = /^(?=.*\s)/;
    if (isWhitespace.test(value)) {
        return "Password tidak boleh ada spasi.";
    }


    const isContainsUppercase = /^(?=.*[A-Z])/;
    if (!isContainsUppercase.test(value)) {
        return "Password harus mengandung karakter huruf kapital.";
    }


    const isContainsLowercase = /^(?=.*[a-z])/;
    if (!isContainsLowercase.test(value)) {
        return "Password harus mengandung karakter huruf kecil.";
    }


    const isContainsNumber = /^(?=.*[0-9])/;
    if (!isContainsNumber.test(value)) {
        return "Password harus mengandung karakter angka.";
    }


    const isContainsSymbol =
        /^(?=.*[~`!@#$%^&*()--+={}\[\]|\\:;"'<>,.?/_₹])/;
    if (!isContainsSymbol.test(value)) {
        return "Password harus mengandung karakter spesial karakter.";
    }


    const isValidLength = /^.{8,15}$/;
    if (!isValidLength.test(value)) {
        return "Password harus minimal 8 karakter dan tidak boleh dari 15 karakter.";
    }

    return "Success";
}

function TampilPassword() {

    var PasswordLama = document.getElementById("PasswordLama");
    if (PasswordLama.type === "password") {
        PasswordLama.type = "text";
    } else {
        PasswordLama.type = "password";
    }

    var PasswordBaru = document.getElementById("PasswordBaru");
    if (PasswordBaru.type === "password") {
        PasswordBaru.type = "text";
    } else {
        PasswordBaru.type = "password";
    }
}
   
    

