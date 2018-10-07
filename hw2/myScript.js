$(document).ready(function() {
    btn1();
    convert();
    mvimg();
});

function btn1() {
    var name1;
    var season1;

    $('#button1').one('click', function () {
        name1 = $('#name').val();
        season1 = $('#season').val();
        var ans = "Welcome " + name1 + "! ";
        var seans = "Your favorite season is " + season1;

        $('#response').append(ans + " " + seans);

        $('.input-control.input-sm').val('');

    });
}

function convert() {
    var temp1;
    var radval;
    var ans;
    var fans;

    $('#button2').one('click', function() {
        temp1 = $('#temp').val();
        radval = $('input:radio[name=temperature]:checked').val();

        if(!$.isNumeric(temp1)) {
            alert("That is not a number.");
        }
        else {
            if(radval == "fahrenheit") {
                ans = (temp1 - 32) * .5556;
                $('#frm2div').append(ans.toPrecision(2) + " C");
            }
            else if(radval == "celsius") {
                ans = temp1 * 1.8 + 32;
                $('#frm2div').append(ans.toPrecision(2) + " F");
            }
        }
        $('#temp').val('');
    });
}

function mvimg() {
    var i = 0;
    $('#cdimg').on('click', function(i) {
        $(this).append("<img src='imgSpring/" + (i++) + ".jpg' width='100%' height='100%' />");
    });
}