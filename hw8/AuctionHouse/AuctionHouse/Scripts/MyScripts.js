$(document).ready(function () {
    reloadPage();
});

function reloadPage() {
    $("#refresh").load(function () {
        $(this).unwrap();
    });
}

setInterval(function () {
    reloadPage();
}, 5000);

    $.ajax({
        method: "GET",
        dataType: "Json",
        url: "..\..\Bid\BidItem",
        contentType: "application/JSON, charset=utf-8",
        async: true,
        success: function (data) {
            var jsonObj = data.d;
            var strHTML = <tr><th>BuyerFullName</th><th>BidAmount</th></tr>;
            $(jsonObj).each(function () {
                var row = $(this)[0];
                strHTML += '<tr><td>' + row["BuyerFullName"] + '</td><td>' + row["BidAmount"] + '</td></tr>';
            });
            $("#resultdiv").html(strHTML);
        },
        error: function () {
            alert("An Error Occurred");
        }
    });



