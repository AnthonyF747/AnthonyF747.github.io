<Query Kind="Statements">
  <Connection>
    <ID>7692fc72-ae85-40d4-88a2-8a69be1046b8</ID>
    <Persist>true</Persist>
    <Driver>EntityFrameworkDbContext</Driver>
    <CustomAssemblyPath>C:\Users\anthony\gitStuff\Gitpage\hw6\Project6\Project6\bin\Project6.dll</CustomAssemblyPath>
    <CustomTypeName>Project6.Models.WWIContext</CustomTypeName>
    <AppConfigPath>C:\Users\anthony\gitStuff\Gitpage\hw6\Project6\Project6\Web.config</AppConfigPath>
  </Connection>
</Query>

var fstname =
	from p in People
	select ( new 
	{
		p.FullName,
		p.PreferredName,
		p.PhoneNumber,
		p.FaxNumber,
		p.EmailAddress,
		p.ValidFrom,
		p.Photo
	});
	
foreach(var p in fstname)
{
	Console.WriteLine(p);
}