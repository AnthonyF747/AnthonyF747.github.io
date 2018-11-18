# Homework 7 Journal

This assignment has us using Giphy to bring data in from an outside source using APIs. Routing will be handled with custom routing tables. 

We are to start with an empty project and build off of that. I added a layout page which contains bootstrap, jquery, javascript, and a link to MyScripts.js which contain my code to run the language translator page. My controller is 'APIController' and the routing page was changed accordingly so the controller was found upon loading the page.

Here is the layout code:

    <!DOCTYPE html>
    <html>
        <head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>@ViewBag.Title - Internet Language Translator</title>
    <link href="~/Content/Site.css" rel="stylesheet" type="text/css" />
    <link href="~/Content/bootstrap.min.css" rel="stylesheet" type="text/css" />
    <script src="~/Scripts/modernizr-2.6.2.js"></script>
    <script type="text/javascript" src="@Url.Content("/Scripts/jquery-3.0.0.min.js")"></script>
    @RenderSection("Javascript", required: false)

    </head>
    <body>
    <div class="banner">
        <div class="container">
            <h1>CS 460 Homework 7</h1>
        </div>
    </div>

    <div class="container body-content">
        @RenderBody()
        <hr />
        <footer>
            <p>&copy; @DateTime.Now.Year - Anthony Franco</p>
        </footer>
    </div>

    <script src="~/Scripts/jquery-1.10.2.min.js"></script>
    <script src="~/Scripts/bootstrap.min.js"></script>
    </body>
    </html>
    
The index page: 

    @{
    ViewBag.Title = "Index";
    }

    <div class="container-fluid">
    <div class="col-md-12" id="indexheader">
        <h2>Internet Language Translator</h2>
    </div>
    <div class="input-group" id="entertext">
        <div class="col-md-12">
            <span class="input-group-btn">
                <label for="textbox"></label>
                <input class="form-control" type="text" id="textbox" />
                <button class="btn btn-primary btn-sm" type="reset" id="clearsrn">Clear Textbox</button>
            </span>
        </div>
    </div>
    <div class="row" id="resultrow">
        <p id="ptxt"></p>
    </div>
    </div>


    @section Javascript
    {
    <script type="text/javascript" src="~/Scripts/MyScripts.js"></script>
    }

The routing table at this point:

    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "API", action = "Index", id = UrlParameter.Optional }
            );
        }
        
The current state of the controller:

    namespace Project7.Controllers
        {
    public class APIController : Controller
    {
        // GET: API
        public ActionResult Index()
        {
            return View();
        }
    }
    }
    
MyScripts.js file currently, includes duplicating text to a div and a clear button that clears both areas:

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
    
This is what the landing page looks like:

![alt-text](img/landingpage.JPG)

When inputing text in the textbox, the text will appear in a div below the textbox in real-time:

![alt-text](img/duptext.JPG)

After clicking the 'Clear Textbox' button:

![alt-text](img/afterclear.JPG)

