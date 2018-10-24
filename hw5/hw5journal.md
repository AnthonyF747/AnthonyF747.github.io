# Journal for Homework 5

Ok, after 4 weeks, I decided to start the journal and add to it as I go because trying to recreate stuff later has been like playing catch-up at the end of the week. 

Since my failure with getting the button, on week 4's ColorChooser view, to find the post method in the ColorController, I'm hoping that working with a model might solve some of the confusion. I'm almost positive that we need to put something in the .gitignore to make certain items in this project to be in the GitHub repository while other items are not included. This might be a question rather than research.

Well, here we go with the project. 

This project has us creating a maintenance form for an apartment/rental environment. When a tenant has a maintenance issue, the tenant fills out the online form and submits it for management or the maintenance person to handle the request. The application will have a database that stores the information entered on the form which includes the tenant's name, apartment number, and maintenance required.

After loading and committing project 5, I changed the shared nav-bar to new links. I decided to go with "Fix It" as my apps name. The two other links will be a "request" link to the maintenance form for tenants to fill out when they have a maintenance issue, and the last page will be for the maintenance/management personnel to get information from the database.

The current nav-bar looks like: 

![alt-text](img/navbar.JPG)

I worked on the `Index.cshtml` landing page. It took a while to figure out how to get a background picture for the page, but I did it YAY!! I'm not thrilled with the `div` that has the button to the `Request` page, but it will do for this project.

Landing page:

![alt-text](img/landpage.JPG)

The code was simple:

    <div class="container">
            <div class="jumbotron">
            <h1>Welcome to Fix It</h1>
            <p>
                Fix It is a new way to get your maintenance needs known without having to
                pick up the phone and call your property manager. Just fill out a simple 
                form and get your repairs requests in quickly at your convenience.</p>
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="request-btn">
                    <p><bold>
                        Any repairs that need to be addressed will be serviced
                        in an orderly manner. In case of a major repair, we will
                        contact you so we can assess the damage before any work
                        begins. To start your maintenance request, please click on
                        the link.
                    </bold></p>
                    @Html.ActionLink("Fix It", "Request", "Request", new { @class = "btn btn-primary" })
                </div>
            </div>
        </div>
    </div>
    
Adding the background picture to the body:

    body {
        background-image: url(../Content/images/apartmentpic.jpg);
        width: 100%;
        height: auto;
        padding-top: 50px;
        padding-bottom: 20px;
    }
    
In order to get the background image, I had to create an image folder in the `Content` folder and add the image to it. Then,
I added a new bundle so the image would be found in that folder:

        bundles.Add(new ScriptBundle("~/bundles/css").Include(
                      "~/Content/css/Site.css",
                      new CssRewriteUrlTransform()
                  ));
                  
The source stated that this code will link to locale paths. I guess it worked because the picture finally showed up on the page.
    
Style for the button `div`:

    .request-btn {
        width: 300px !important;
        height: 289px !important;
        color: black;
        background-color: slategray;
        padding: 10px;
        margin: 10px;
        text-align: center center;
        opacity: 0.9;
    }

Now to tackle the model portion of the project. This didn't take too long:

    namespace Project5.Models
    {
        public class Tenant
        {
            [Required]
            [StringLength (20)]
            public string FirstName { get; set; }
            [Required]
            [StringLength (25)]
            public string LastName { get; set; }
            [Required]
            [StringLength (10)]
            public string PhoneNumber { get; set; }
            [Required]
            [StringLength (30)]
            public string ApartmentName { get; set; }
            [Required]
            [StringLength (4)]
            public string UnitNumber { get; set; }
            [StringLength (500)]
            public string Description { get; set; }
        }
    }
    
I put required on everything except for the `Description` portion. I'll probably add a `Required` validation to force the user to
input a short description of the maintenance issue. The management/maintenance personnel should know what kind of repair is needed.
