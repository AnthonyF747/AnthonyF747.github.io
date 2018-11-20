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
            $("#testtxt").text("True");
        }
    })
    .keyup();                               // call the function for every keyup
}

function cleardiv() {                       // function to clear the textbox and the 'resultrow' div
    $("button").click(function () {         // trigger an event when the button is clicked
        $("#resultrow").empty();            // set 'resultrow' to empty to clear div
        $("#textbox").val('');              // set 'textbox' value to '' which clears the div
    });
}

function getWord() {
    var value = $(this).val();
    var word = value.split(" ");
    var preWord = word[word.length - 1];
        
    $("#texttxt").text(preWord);
    $.ajax({
        type: "Post",
        dataType: "Json",
        url: "../Translate/" + preWord,
        success: functionName,
        error: errorOnAjax
    });
}

