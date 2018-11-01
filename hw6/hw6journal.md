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