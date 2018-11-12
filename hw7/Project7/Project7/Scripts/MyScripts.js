$(document).ready(function () {
    $('#inputtxt').keyup(function (e) {
        var txtVal = (this).val();
        $('#output').val(txtVal);
    });

    $('#output').keyup(function (e) {
        var txtVal = (this).val();
        $('#inputtxt').val(txtVal);
    });
});
