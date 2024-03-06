# WebAppFinal
7SENG014W Web Application Development: Project 01 (Backend RESTful Service)
Step 1:

I created a repo on GitHub called “WebAppFinal”

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/e88e30a3-fee3-44f0-999b-1ab7d0dd6bf0/Untitled.png)

Step 2: I cloned the Connected the Repo from GitHub onto my laptop. Additionally, I ran the command “`Cd C:\Which\Contains\source\repos\from my github` on Command prompt. This allowed me to change to this directory. Once, I was in the correct Directory. I ran the command  `dotnet  new Webapi`” . This generated the following  template for me in the folder. 
 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/3103e745-3a3a-4ea8-a53c-07e0cd4f44a2/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/bf6ea52f-20c8-4f1b-a700-82e6711b9bb1/Untitled.png)

Step 3: After Running the following Command I should get a template generated like this. Unfortunately, my Models and Controllers. Didn't Autogenerate. I’ve had to now create Folders called Models and Controllers. 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/da8b1d0e-915f-4e85-ace2-b34a6ed1dc34/Untitled.png)

Step 4. I’ve created 5 Model classes. My Project is based on a Supermarket. The 5 Model classes I’ve created are Customers.cs , Product.cs , Category.cs , Basket.cs , and Order.cs. The Models are the data and business logic. They contain the structure  and behaviour of the data in our application  

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/fe0ea35c-7e3e-4122-be50-e507e3a22beb/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/8d0453bb-71ce-4f21-84d3-ee54893bebe2/Untitled.png)

Step 5: It’s time to create a DbContext class which will be used for Dependency injection. DbContext, which represents the database session in Entity Framework Core, is provided to the class from outside rather than being created within the class itself. This allows for better decoupling, testability, and flexibility in managing the database connection and operations within the application.  Additionally, Installed EntityFrameworkCore in Via Nuget Package Manager.  Installing the EntityFrameworkCore dependency provides functionality for my DbContext model to interact with a database using Entity Framework Core. This allows you to define your database schema using C# classes and manage database operations such as querying, inserting, updating, and deleting data more easily and efficiently.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/9d868498-93d3-4d73-8299-99fe4ff7385a/Untitled.png)

Step 6 : In order to Register the context with Dependency injection. I’ve entered the following code in our Program.cs. Additionally, I’ll need to install Microsoft.EntityFrameworkCore.SqlServer. This be used for  interacting with Microsoft SQL Server databases. When you install this package as a dependency, it enables your DbContext model to work specifically with SQL Server databases, providing support for features and optimizations tailored to SQL Server. 

`builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));`

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/2edd0a50-8941-4674-a56d-0408f22607ca/Untitled.png)

Step 7: I’m going to now add the Database Connection String Into my Appsettings.Json File: The purpose of this configuration is to provide the necessary information for the application to establish a connection to the database.  The Json syntax will look like this 

`{
"ConnectionStrings": {
"Connection": "Server=(localdb)\\MSSQLLocalDB;Database=Pickname;Trusted_Connection=True;"
}
}`

Step 8: It now time to add Migrations via the NuGetPackmanager Console.  However, Before doing this Install Microsoft Entity Framework Core Tools.

 Tools - NutGetPackage Manager - Package Manager Console 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/edc5a2e3-13ee-4177-8925-e6ec5b8af27e/Untitled.png)

Enter the following Commands into the console 

(This will create a class name InitalCreate in which code to create tables for my models will be present)

Update-Database
(This will create a Database based on information From initialCreateClass) 

Add-Migration InitialCreate

A Folder called Migrations will be created 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/44e7f0ce-ad83-4d5e-a7a1-f5cd4170170f/Untitled.png)

The Next Command is Update-Database. 

In My Project I was getting the Following Error message. This was preventing me from creating my Database. In order to fix this you’ll need to make change on your Project SDk File

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/f6a621ed-7526-405f-ba23-a981ca0e8199/Untitled.png)

You’ll need to change the following from True to False. In order to fix the issue. 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/b2743474-c982-46a7-bf31-eed117af79d9/Untitled.png)

Step 9: If successful, You should get this Database appearing on your local machine.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/5c20fd8c-ba33-4864-abb9-924c19d1576b/Untitled.png)

Step 10: Now, I’ll need to create the Api controllers for the my Models. the API controllers typically handle incoming HTTP requests and generate appropriate HTTP responses. These controllers are responsible for processing data, interacting with my Database Server. 

  Controllers Folder - right Click and select Add  and click on Controller.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/68de96df-1c76-431c-804c-bea3e0303465/Untitled.png)

Step 11: Once, you're on this page. Select the following. Under common click on Api and Select Api controller with actions, Using Entity Framework. This will Auto generate a Api Controller class using my Model class and Dbcontext. This will allow me to implement CRUD functions into my Application. 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/5f3c9fed-5781-4631-b886-356358f9518c/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/4b9904db-faf3-4e06-a3d3-73151ed772c2/Untitled.png)

Step 12: Once, you’ve generated all your controllers. You should have the following in your controllers folder. 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/34d50901-4998-461a-bce3-01a77b1851a7/Untitled.png)

Step 13: In this Step i will be adding a Identity support into my Application to allow things like user accounts,Sign up, Sign in and Sign out. I start of by Installing the following Framework Microsoft.AspNetCore.Identity.EntityFrameworkCore. Once this has been installed. I’ll add the following code to my Dbcontext and change it from `public class SupermarketContext : DbContext`  to `public class SchoolContext : IdentityDbContext<IdentityUser>`. Additionally, Adding the Following to the top of my Dbcontext.cs. 

`using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;`

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/c6795169-6ea0-4f85-89b4-daada34f5191/Untitled.png)

Step 14: In my Program.cs I need to add another dependency injection. 

`builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<SchoolContext>().AddDefaultTokenProviders();`
This is necessary for setting up user authentication, authorization, and management functionality within an [ASP.NET](http://asp.net/) Core application. Once, I’ve added this to my Program.cs I need to add the `using Microsoft.AspNetCore.Identity;`   

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/a1be4339-dd7f-4da0-9a6e-b9101465b3ea/Untitled.png)

Step 15: In my Migration folder i will created a class  called IdentityAdded. Using the following Command `Add-Migration IdentityAdded`  

I’ll go to tools -> NuGet package manager -> Package manager console
And type in `Add-Migration IdentityAdded`  

If it is successful, you will see a change in migrations
folder.

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/ebe10bfe-5fb0-4e02-ab58-e4cafecf13f5/Untitled.png)

  
Now, I’ll enter the Command `Update-Database.`  if look at the database now, new tables have been added

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/39db2c0f-80fd-43cd-9361-ec7cdfc0d3a0/Untitled.png)

Step 16:  I’ll need to download a dependency called Mailkit.  Go to the tools -> NuGet Package manager -> Manage NuGet packages for solution and browse and install the package MailKit. 

Step 17: I’ll now need to create the sign in functions. by creating a Authentication class in my Models folder. 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/a72e5cb4-20a3-4aed-89b7-2351ab2a2100/Untitled.png)

Step 18: I’ll create a folder name services in which it will allow me to create a Emailservice class and a email settings.class. It will look like the following image. 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/9586671c-c507-4cc5-bdd1-516f45bf8509/Untitled.png)

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/c10a97de-c981-4405-b593-c25442373536/Untitled.png)

Step 19: Now it’s time for me to build the AccountController.cs.  by right clicking the controller folder and add new file. Make Sure to select the following 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/364995e3-4959-4611-b64f-3858a41d6e85/Untitled.png)

Step 20:  I need to now register my email service in my Program.cs.
`builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<EmailService>();`

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/0bb39655-6496-4f21-8959-f205e5430d47/Untitled.png)

Step 21: Now I need to mention the configuration via my Json file 

`"EmailSettings": {
"SmtpServer": "[smtp.gmail.com](http://smtp.gmail.com/)",//only valid for gmail
"SmtpPort": 587,
"SmtpUsername": "[yourgmailaccount@gmail.com](mailto:yourgmailaccount@gmail.com)",//create a testing gmail account
"SmtpPassword": "your gmail app password"//use one time generated app password
},`

Important Side not: I kept getting errors like this in my program when running it “**No operations defined in spec!”**   

This  was due to me not inputting two very important statements. Make sure to add these and test your API endpoints. 

`builder.Services.AddControllers();`   `app.MapControllers();.`

Step 22:  I’ve created a random email account to test that this is working as it will send a verification email to my dummy email. 

Test 1: 

![Untitled](https://prod-files-secure.s3.us-west-2.amazonaws.com/67183c3d-d89e-445d-9296-53954172b59d/63594800-e386-4d5d-8437-70229f29c346/Untitled.png)

Result:
