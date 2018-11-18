$(document).ready(function () {
    $("input")
        .keyup(function () {
            var value = $(this).val();
            $("#ptxt").text(value);
        })
    .keyup();
});