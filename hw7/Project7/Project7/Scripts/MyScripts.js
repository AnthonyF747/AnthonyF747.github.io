$(document).ready(function () {
    $("input")
        .keyup(function () {
            var value = $(this).val();
            $("#ptxt").text(value);
        })
        .keyup();
    cleardiv();
});

function cleardiv() {
    $("button").click(function () {
        $("#resultrow").empty();
        $("#textbox").val('');
    });
}
