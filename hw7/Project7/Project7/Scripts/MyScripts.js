/// MyScripts.js is where my jQuery scripts reside for use
/// in Project 7. Most functions deal with the textbox and 
/// the input provided by the user.
/// Author: Anthony Franco
/// Date: November 20, 2018
/// Class: CS460 Software Engineering I
/// Assignment: Homework 7
/// Description: Sending data to a Url and receiving gifs from Giphy API

$(document).ready(function () {             // load functions when the document is loaded
    inputText();
    cleardiv();
});

/// inputText() works on a keypress function
/// which checks every key stroke. The text
/// will be sent to a div to display the textbox
/// input, and it will be checked for a space.
/// When a space is encountered, the getWord() 
/// function is called.
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

/// Button to clear the textbox and the #ptxt div.
/// The page will also reload in order to get the 
/// div results to show up again after button is pressed.
function cleardiv() {                       // function to clear the textbox and the 'resultrow' div
    $("button").click(function () {         // trigger an event when the button is clicked
        $("#resultrow").empty();            // set 'resultrow' to empty to clear div
        $("#textbox").val('');              // set 'textbox' value to '' which clears the div
        location.reload();
    });
}

/// Used to get the previous word for evaluation and
/// to set up ajax for requests
function getWord() {                        // function to get the previous word and get ajax set up
    var value = $("input").val();           // putting the input from the textbox into 'value' variable
    var word = value.split(" ");            // split the values entered and put them in the word variable
    var preWord = word[word.length - 1];    // store the word entered before the spacebar was hit into preWord variable
        
    $("#testtxt").text(preWord);
    $.ajax({
        type: "Post",                       // set the send method of post
        dataType: "Json",                   // the type of data being sent is Json
        url: "../Translate/" + preWord,     // use translate/preWord<value> in the url
        success: checkWord,                 // use the displayPanel function
        error: ajaxError                    // or, send error
    });
}

/// Error for ajax code
function ajaxError() {                       // function that will throw error if gif doesn't load
    console.log("Error in Ajax code");       // send message to console
}

/// This function takes the word input and evaluates it
/// to see if it is a string that will be used to retrieve
/// a gif or not.
/// <param name="word">the word to evaluate</param>
function checkWord(word) {                  // function to evaluate the word
    if (typeof word == "string") {          // compare type of word to string
        $("#ptxt").append(word);            // append the word to the div
    } else {                                // if special word,
        displayGif(word.data.embed_url);    // call function to get a gif
    }
}

/// A function to display the gif in the div (#ptxt)
/// <param name="source">The source where gif is coming from</param>
function displayGif(source) {                // function to display the gif
                                             // get the gif, set the size, store it in 'gif' variable
    var gif = '<iframe src=" ' + source + '" width="150" height="200" class="gifpic"></iframe>';
    $("#ptxt").append(gif);                  // append the gif to #ptxt div
}
