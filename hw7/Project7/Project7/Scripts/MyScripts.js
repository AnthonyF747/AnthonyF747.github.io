$(document).ready(function () {             // load functions when the document is loaded
    inputText();
    cleardiv();
});

function inputText() {                      // function for the textbox and displaying input
    $("input").keypress(function (e) {      // a keypress function for the 'input' div (textbox)
        var value = $(this).val();          // store the input value to variable 'value'
        $("#ptxt").text(value);             // print out the value to the 'ptxt' div
                                            // check if the input value is a space or spacebar element
        if (e.key == " " || e.key == "spacebar") {
            getWord();                      // call the getWord function to get a word
        }
    });
}

function cleardiv() {                       // function to clear the textbox and the 'resultrow' div
    $("button").click(function () {         // trigger an event when the button is clicked
        $("#resultrow").empty();            // set 'resultrow' to empty to clear div
        $("#textbox").val('');              // set 'textbox' value to '' which clears the div
        location.reload();
    });
}

function getWord() {                        // function to get the previous word and get ajax set up
    var value = $("input").val();           // putting the input from the textbox into 'value' variable
    var word = value.split(" ");            // split the values entered and put them in the word variable
    var preWord = word[word.length - 1];    // store the word entered before the spacebar was hit into preWord variable
        
    $("#testtxt").text(preWord);
    $.ajax({
        type: "Post",                       // set the send method of post
        dataType: "Json",                   // the type of data being sent is Json
        url: "../Translate/" + preWord,     // use translate/preWord<value> in the url
        success: functionName,              // use the function
        error: errorOnAjax                  // or, send error
    });
}

