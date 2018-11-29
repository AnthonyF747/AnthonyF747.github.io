#Journal for Homework 8

After the last two homework assignments, I'm glad I have some basic knowledge of how to get the website and database going. I also got the controllers and crud items for each table item from the database. Joy at last. Here are some highlights of this assignment.

Class diagram for the database:

![alt-text](img/auctionCD.JPG)

The landing page:

![alt-text](img/landingPage.PNG)

The code for the landing page:

    @{
    ViewBag.Title = "Home Index";
    }

    <div class="jumbotron jumbotron-fluid" id="jumpic">
    <div class="container-fluid">
        <h1>Anthony's Online Auction House</h1>
        <p>
            Where you can find the most worthless stuff
            on the planet.
        </p>
    </div>
    </div>
    <div class="row">
    <div class="container-fluid">
        <div class="col-md-3">
            <div class="card-group">
                <div class="card-body">
                    <h3 class="card-title">Sellers</h3>
                    <p>
                        If you have stuff laying around the house that you really don't
                        want anymore, here is a site to get rid of it and make some money.
                        All you have to do is fill out a simple form to get started and
                        let the bidding begin. Click the link to get started.
                    </p>
                    <a href="/Home/CheckName" class="card-link">Seller's Form</a>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card-group">
                <div class="card-body">
                    <h3 class="card-title">Buyers</h3>
                    <p>
                        Sometimes the items we have are not enough and we need to look for
                        stuff that we don't need. Sometimes there is that little special
                        something that catches our eye and have a use for that item. If you
                        are in the market for a gadget to buy, you've come to the right place.
                        Click the link to get started.
                    </p>
                    <a href="/Home/CheckBuyer" class="card-link">Buyer Registration</a>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card-group">
                <div class="card-body">
                    <h3 class="card-title">Items</h3>
                    <p>
                        You can look through the list of items that are up for bid and the
                        items that have been sold. Items are posted to the site and will be
                        available for sale until the item is sold or the seller decides not
                        to continue with the sale of the item.
                    </p>
                    <a href="/Items/Index" class="card-link">List of Items for Sale</a>
                </div>
            </div>
        </div>
        <div class="col-md-3">
            <div class="card-group">
                <div class="card-body">
                    <h3 class="card-title">Bids</h3>
                    <p>
                        Take a look at the current and past bids. If you do find that special
                        item, go ahead and place a bid on it but don't forget to register first.
                        Please use the Buyer's Registration link to sign up and begin your bidding.
                    </p>
                    <a href="/Bids/Index" class="card-link">Bids</a>
                </div>
            </div>
        </div>
    </div>
    </div>
    
At the top of the landing page, there is a navbar with 5 elements. The first is the "Home" link which takes a user back to the landing page. The next four links will display the list of database entries for that specific element, such as a list of sellers in the database. I used scaffolding when building the controllers and views for the tables elements and have removed most of the links except for the details link. 

The landing page contains four card elements for seller, buyer, item, and bid. When a user comes on to the webpage and wants to buy or sell an item, they will click on the link at the bottom of the appropriate card and be taken to a check account page. On this page, the user will be prompted to enter their phone number to determine if they have bought or sold on the site previously. If they have not, the user is redirected to enter their full name, phone number, and email address in order to post an item or post a bid for an item. 

Here is the check account page:

![alt-text](img/checkAccountView.JPG)

Here is the code for the checkAccountView:

    @{
    ViewBag.Title = "CheckName";
    }

    <h2>Check Account</h2>
    <p class="lead">First, let's check if you have an account</p>

    @using (Html.BeginForm())
    {
    @Html.AntiForgeryToken()

    <div class="form-horizontal">
        <h4>Check for Name</h4>
        <hr />
        @Html.ValidationSummary(true, "", new { @class = "text-danger" })
    </div>
    <div class="form-group">
        @Html.Label("Please Enter Your Phone Number")
        <div class="col-md-10">
            @Html.TextBox("phoneNumber", null, new { @class = "form-control" })
        </div>
    </div>
    <button class="btn btn-primary btn-sm" type="submit">Submit</button>
    }
    

