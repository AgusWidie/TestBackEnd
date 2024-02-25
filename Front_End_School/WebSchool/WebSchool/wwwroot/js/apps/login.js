
function login() {

    try {
        var NamaPengguna = document.getElementById("NamaPengguna").value;
        var Password = document.getElementById("KataSandi").value;

        if (NamaPengguna == "") {
            Swal.fire('Informasi',
                'Nama Pengguna Masih Kosong..!',
                'warning')
            return;
        }

        if (Password == "") {
            Swal.fire('Informasi',
                'Kata Sandi Masih Kosong..!',
                'warning')
            return;
        }

        var data = { NamaPengguna: NamaPengguna, Pass: Password };
        var stringData = JSON.stringify(data);


        $.ajax({

            type: "POST",
            url: "Login/LoginPengguna",
            data: stringData,
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (data) {
                if (data.error == false) {
                    window.location.href = "/Home/Index";
                }
                else {
                    Swal.fire('Informasi',
                        'Error Login..!',
                        'danger')
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
