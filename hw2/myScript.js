$(document).ready(function() {
    btn1();                 // Stage all three functions when document is finished loading
    convert(); 
    mvimg();
});

// First button function
function btn1() {
    var name1;               // var for name input
    var season1;             // var for season input

    $('#button1').one('click', function () {     // When button is clicked, fire function one time
        name1 = $('#name').val();                // Store value from name input field in name1 var
        season1 = $('#season').val();            // Store value from season input field in season1 var
        var ans = "Welcome " + name1 + "! ";     // var ans stores the welcome message and adds name1
        var seans = "Your favorite season is " + season1;  // var seans stores the season message and adds season1

        $('#response').append(ans + " " + seans);          // Append the messages to the response div

        $('.input-control.input-sm').val('');              // Clear the input fields of data

    });
}

// Button 2 function with radio buttons and input check
function convert() {
    var temp1;          // var for temperature input
    var radval;         // var for radio button checked
    var ans;            // var for conversion result

    $('#button2').one('click', function() {      // Fire event one time after button click
        temp1 = $('#temp').val();                // Store temperature input in temp1
        radval = $('input:radio[name=temperature]:checked').val();  // Check the radio button and store selected in radval

        if(!$.isNumeric(temp1)) {                // Check if temp1 is a number
            alert("That is not a number.");      // If not, send an alert to the user
        }
        else {
            if(radval == "fahrenheit") {         // If true, check to see if radval is fahrenheit
                ans = (temp1 - 32) * .5556;      // The conversion for fahrenheit to celsius
                $('#frm2div').append(ans.toPrecision(2) + " C");   // Append the answer to frm2div and reduce to two digits
            }
            else if(radval == "celsius") {       // If not fahrenheit, check if radval is celsius
                ans = temp1 * 1.8 + 32;          // The conversion for celsius to fahrenheit
                $('#frm2div').append(ans.toPrecision(2) + " F");   // Append the answer to frm2div and reduce to two digits
            }
        }
        $('#temp').val('');                      // Clear the temp input field
    });
}

function mvimg() {
    var i = 0;
    $('#cdimg').on('click', function() {
        $(this).append("<img src='imgSpring/" + (i++) + ".jpg' width='100%' height='100%' />");
    });
}