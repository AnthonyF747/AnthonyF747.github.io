# Journal for Homework 4

Well, I'm totally down on myself for this week's project. We are learning ASP.NET MVC 5, and I thought that I was doing so well until...I messed something up and have to recreate my project. I'm going to make the best of this situation and take snapshots as I go since I didn't do this the first time around. 

The `Converter`, which is where the page will accept a number (which is the number of miles to convert) from the user and convert that number to one of four metric types: millimeters, centimeters, meters, and kilometers. I previously had this working properly using `razor` but when I merged the work with the master, all the code was gone. It all reverted back to `HTML` that I used to build the original pages. When I spoke to Dr. Morse one day after class, I sounded like all the code was be in `razor`, but I was incorrect. I used a separate branch to create the `Converter` and didn't push to a master and that is more than likely the reason for the code not merging properly. I'm still trying to figure this out, but with nine hours to turn this project in, I don't have time to troubleshoot many issues. So, here we go building a new project from the beginning.

Here is a portion of the first commit:

![alt-text](img/firstCommit.JPG)

This is how the new project looks when it is created:

![alt-text](img/newProject.JPG)

The web view of the new project:

![alt-text](img/webView1.JPG)

After changing the `_Layout.cshtml` page, I recoded the `Index.cshtml` page to get the required start page.

    <div class="jumbotron">
        <h1>CS 460 Homework 4</h1>
        <p class="lead">A few forms and some simple server-side logic -- learning the basics of GET, POST, query strings, form data
        and handling it all from an ASP.NET MVC 5 application.</p>
        <p><a href="/Home/Index" class="btn btn-info btn-lg">Learn more &raquo;</a></p>
    </div>

    <div class="row">
    <div class="col-md-6">
        <h2>Mile to Metric Converter</h2>
        <p>
            Want to know how many millimeters there are in 26.2 miles? This calculator is for you. Use query strings to send
            form data to the server, which performs the calculation and returns the answer in the requested page.
        </p>
        <p><a class="btn btn-primary" href="/Home/Converter">Try it out &raquo;</a></p>  
    </div>
    <div class="col-md-6">
        <h2>Color Chooser</h2>
        <p>Typical online color choosers are way too useful. We wanted something fun and completely useless. This form POSTs
        the data to the server.</p>
        <p><a class="btn btn-primary" href="/Color/ColorChooser">Check it out &raquo;</a></p>
    </div>
    </div>

The new start page:

![alt-text](img/newStartPage.JPG)

In the next step, I created a new `Converter` controller in the `Home` controller.

![alt-text](img/createConvertControl.JPG)

The `Converter` view code to set up radio buttons and textbox:

    <h2>Convert Miles to Metric</h2>

    <div class="container-fluid">
        <div class="row">
            <form action="/Home/Converter" method="get" name="form1">
                <div class="col-md-6">
                    <div class="form-group">
                        <label for="MilesToConvert">Miles:</label>
                        <input type="text" name="MilesToConvert" value="" class="form-control"/>
                    </div>
                </div>
            <div class="col-md-6">
                <h3>Select a Unit</h3>
                <hr />
                <div class="radio">
                    <label><input type="radio" name="Units" value="millimeters" checked/><strong>millimeters</strong></label>
                </div>
                <div class="radio">
                    <label><input type="radio" name="Units" value="centimeters" /><strong>centimeters</strong></label>
                </div>
                <div class="radio">
                    <label><input type="radio" name="Units" value="meters" /><strong>meters</strong></label>
                </div>
                <div class="radio">
                    <label><input type="radio" name="Units" value="kilometers" /><strong>kilometers</strong></label>
                </div>
            </div>
            <div align="center">
                <input type="submit" value="Convert" class="btn btn-primary" />
            </div>
        </form>
    </div>
    <h3 style="color: red">@ViewBag.RegexMessage</h3>
    <h3 style="color: darkred">@ViewBag.Message</h3>
    </div>


Here is the `Converter` view:

![alt-text](img/convertView.JPG)

After adding input to `Converter`:

![alt-text](img/conViewWData.JPG)

I was having issues with getting a tooltip stlye alert to work if a `string` or `char` is entered into the miles textbox, so I added a ViewBag that displays a message if a number is not entered.

![alt-text](img/conWString.JPG)

The next thing I did was add the `ColorController` and configured the route.

![alt-text](img/slnOverview.JPG)

I'm trying to figure out the `ColorTranslator` and `System.Drawing` to get the colors, but haven't figured it out yet. In this image, I'm trying to verify if the input is in the hexidecimal pattern as shown on the view page.

    [HttpPost]
        public ActionResult ColorChooser(string x, string y)
        {
            Color colorOne;
            Color colorTwo;
            Regex regex = new Regex("^#[A-Fa-f0-9]{6} | [A-Fa-f0-9]{3}");

            if(regex.IsMatch(x) && regex.IsMatch(y))
            {
                colorOne = ColorTranslator.FromHtml(x);
                colorTwo = ColorTranslator.FromHtml(y);

                ViewBag.NewColor = "it matches";
            }
            else
            {
                ViewBag.RegexFail = "The value entered was not is proper form. Try #AABBCC pattern";
            }

            
            //Color newColor = colorOne + colorTwo;

            return View();
        }
    }



