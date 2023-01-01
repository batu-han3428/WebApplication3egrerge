// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var hesapkarttip = {
    listele: function() {
        $.ajax({
            url: "https://localhost:7120/Home/GetHomeIndexTable",
            type: 'GET',
            success: function (res) {
                $('#homeindexmain').html("");
                $('#homeindexmain').html(res);
                console.log('dadasda')
            }
        });
    },
    Ekle:function(){
        $('#hesapTipEkle').click(function () {
            var data = $("#myModal .modal-body form").serialize();

            $.ajax({
                url: "https://localhost:7120/Home/AddHesapKartTip",
                data: data,
                type: "POST",
                success: function (res) {
                    if (res.result) {
                        swal("Kayıt Başarılı!", "", "success");
                        $("input[name='Name']").val("");
                        hesapkarttip.listele();
                    } else {
                        swal("Kayıt Başarısız!", "", "error");
                    }
                }, error: function (hata, ajaxoptions, throwerror) {
                    alert("Hata :" + hata.status + " " + throwerror + " " + hata.responseText);
                }
            });
        });
    }
}