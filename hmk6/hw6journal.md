# Journal for Homework 6

Well, we have arrived to week 6. The pace is fast, and I don't think I have fully completed the assignments since week 3. I am trying to get a majority of the work complete before moving on to the next project. I'm proud of myself for figuring out the database and getting data in and out of it on the last day I was going to work on Project5 before starting Project6, so maybe I'll be able to figure this out with that discovery. Here we go...

I loaded Project 6 and added the database using SQL Manager:

![alt-text](img/sqlManager.JPG)

Then, I loaded the Entity Framework package:

![alt-text](img/AddingEntityFramework.JPG)

Next, I loaded the Microsoft.SqlServer.Types package:

![alt-text](img/installSqlServerTypes.JPG)

The next step adds a couple lines of code to the global.asax.cs file to connect with SqlServerTypes:

    protected void Application_Start()
        {
            // For Spatial types, i.e. DbGeography
            SqlServerTypes.Utilities.LoadNativeAssemblies(Server.MapPath("~/bin"));

            // Fix from https://stackoverflow.com/questions/13174197/microsoft-sqlserver-types-version-10-or-higher-could-not-be-found-on-azure/40166192#40166192
            SqlProviderServices.SqlServerTypesAssemblyName = typeof(SqlGeography).Assembly.FullName;

            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
      }
    }
    
The ADO gets added next:

![alt-text](img/addADO.JPG)

![alt-text](img/ADOonnection.JPG)

![alt-text](img/codeFirst.JPG)

![alt-text](img/postModelADO.JPG)

With Manuel's help, I got Linqpad downloaded and linked to the database. The problem was that I was looking for the database name for the link and not the project name. Also, the dropdown on the top toolbar has to have the database selected in order for the link to work.

![alt-text](img/linqtoolbar.JPG)

I created a view for returning information for the person being searched for:

    public class DisplayPerson
    {
        public string FullName { get; set; }
        public string PreferredName { get; set; }
        public string PhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string EmailAddress { get; set; }
        public DateTime ValidFrom { get; set; }
        public byte Photo { get; set; }

        public override string ToString()
        {
            return $"{base.ToString()}: {FullName} {PreferredName} {PhoneNumber} {FaxNumber} {EmailAddress} {ValidFrom} {Photo}";
        }
    }
    }
    
I don't know what this is?

    λ git add .
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Content/bootstrap-theme.css.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Content/bootstrap-theme.min.css.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Content/bootstrap.css.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Content/bootstrap.min.css.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/bootstrap.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/bootstrap.min.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/jquery-3.3.1.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/jquery-3.3.1.min.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/jquery-3.3.1.slim.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/jquery-3.3.1.slim.min.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/jquery.validate.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/jquery.validate.min.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/jquery.validate.unobtrusive.min.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/Scripts/modernizr-2.8.3.js.
    The file will have its original line endings in your working directory
    warning: LF will be replaced by CRLF in hw6/Project6/Project6/Project6/fonts/glyphicons-halflings-regular.svg.
    The file will have its original line endings in your working directory

    C:\Users\anthony\gitStuff\Gitpage (master -> origin)
  
Ok, I have officially given up on this project. The next project is due in a couple days and I have yet to start it, so I will let Project 6 go for now and maybe I'll understand what is actually going on one day. Total epic failure. 

With help from Scot and my classmates, I finally got the textbox list to work and it is receiving input through the GET form method.

    public class HomeController : Controller
        {
        private WWIDbContext _wwiDb = new WWIDbContext();

        public ActionResult Index(string query)
        {
            if (query == null || query == "")
            {
                ViewBag.show = false;
                return View();
            }
            else
            {
                ViewBag.show = true;
            }
            return View(_wwiDb.People.Where(p => p.FullName.ToLower().Contains(query.ToLower())).ToList());
        }
        
    @model IEnumerable<WWImporters.Models.Person>

    @{
    ViewBag.Title = "Home Page";
    }

    <div class="row" id="txtrow">
    <div class="container-fluid">
        @using (Html.BeginForm("Index", "Home", FormMethod.Get))
        {
            <div class="input-group">
                <span class="input-group-btn">
                    @Html.TextBox("query", null, new { @class="form-control" })
                    <button class="btn btn-primary btn-sm" type="submit" id="frmbtn">Submit</button>
                </span>
            </div>
        }
    </div>
    </div>
    <div class="row">
    <div class="container-fluid">
        @if(ViewBag.show)
        {
            if(Model.Count() == 0)
            {
                <h4 id="hdindex">Name not found. Please try again.</h4>
            }
            else
            {
                <h3>Client Search</h3>
                <div class="list-group">
                    <ul>
                        @foreach (var p in Model)
                        {
                            <li>
                                <a class="text-info" href="Home/PersonInfo/@p.PersonID" role="button">@p.FullName (@p.PreferredName)</a>
                            </li>
                        }
                    </ul>
                </div>
            }
        }
    </div>
    
This is the search list in action:

![alt-text](img/searchlist.JPG)

Code to retrieve the person search selection:

    public ActionResult PersonInfo(int? id)
        {
            GroupInfoView infoView = new GroupInfoView
            {
                ThisPerson = _wwiDb.People.Find(id)
            };
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Person thisPerson = _wwiDb.People.Find(id);
            if(thisPerson == null)
            {
                return HttpNotFound();
            }
            return View("PersonInfo", infoView);
        }
    }
    
This is what it looks like:

![alt-text](img/personinforesult.JPG)

Code to retrieve the company information of a primary contact person:

    ViewBag.SetFlag = false;                         // flag for primary contact person

            if (infoView.ThisPerson.Customers2.Count() > 0)  // check if the customer2 column is greater than 0, which means they 
            {
                ViewBag.SetFlag = true;                      // if greater than 0, set flag to true
                                                             // check the person's customer2 column and get the first customer id
                                                             // and put it in an int variable 
                int custID = infoView.ThisPerson.Customers2.FirstOrDefault().CustomerID;
                                                             // set a customer view with the results of the query
                                                             // this will be sent to the PersonInfo view
                infoView.ThisCustomer = _wwiDb.Customers.Find(custID);
                
This is the view after adding customer code:

![alt-text](img/companyInfo.JPG)

Code for the sales, profit, and inventory items:

    ViewBag.Sales = infoView.ThisCustomer.Orders.SelectMany(s => s.Invoices)
                                                            .SelectMany(c => c.InvoiceLines)
                                                            .Sum(t => t.ExtendedPrice);

                                                            // set a viewbag to hold gross profit value
                ViewBag.Profit = infoView.ThisPerson.Orders.SelectMany(s => s.Invoices)
                                                           .SelectMany(c => c.InvoiceLines)
                                                           .Sum(t => t.LineProfit);

                                                            // create a view to sent to PersonInfo
                infoView.ThisInvoice = infoView.ThisCustomer.Orders.SelectMany(i => i.Invoices)
                                                                   .SelectMany(l => l.InvoiceLines)
                                                                   .OrderByDescending(p => p.LineProfit)
                                                                   .Take(10)
                                                                   .ToList();
            }
            
View of purchaes:

![alt-text](img/purchases.JPG)

Code for the table with items:

    <h2>Purchased Items</h2>
        <div class="container-fluid">
            <div class="col-md-7">
                <table>
                    <thead>
                        <tr>
                            <th>@Html.DisplayName("Stock Item \t")</th>
                            <th>@Html.DisplayName("Description \t")</th>
                            <th>@Html.DisplayName("Profit \t")</th>
                            <th>@Html.DisplayName("Sales Person \t")</th>
                        </tr>
                    </thead>
                    @foreach(var p in Model.ThisInvoice)
                    {
                        <tbody>
                            <tr>
                                <td>@Html.DisplayFor(item => p.StockItemID)</td>
                                <td>@Html.DisplayFor(item => p.Description)</td>
                                <td>@Html.DisplayFor(item => p.LineProfit)</td>
                                <td>@Html.DisplayFor(item => p.Invoice.Person4.FullName)</td>
                            </tr>
                        </tbody>
                    }
                </table>
            </div>
        </div>
    </div>
    }
    
Here is what the table looks like:

![slt-text](img/table.JPG)


Since I was already graded on this project, I am calling it quits and moving on.