# WebAppFinal
7SENG014W Web Application Development: Project 01 (Backend RESTful Service)
Step 1:

I created a repo on GitHub called “WebAppFinal”

![Untitled (2)](https://github.com/YusTech123/WebAppFinal/assets/115075205/3a4d7ac5-8e40-49c4-82a5-2bc6f0d04aaf)


Step 2: I cloned the Connected the Repo from GitHub onto my laptop. Additionally, I ran the command “`Cd C:\Which\Contains\source\repos\from my github` on Command prompt. This allowed me to change to this directory. Once, I was in the correct Directory. I ran the command  `dotnet  new Webapi`” . This generated the following  template for me in the folder. 
 
![Untitled (3)](https://github.com/YusTech123/WebAppFinal/assets/115075205/3666991c-9fd9-4987-940d-f6aa573925e0)


![Untitled (4)](https://github.com/YusTech123/WebAppFinal/assets/115075205/b0f9b1b4-97c0-48d2-8074-5873fd62b2e5)


Step 3: After Running the following Command I should get a template generated like this. Unfortunately, my Models and Controllers. Didn't Autogenerate. I’ve had to now create Folders called Models and Controllers. 
![Untitled (5)](https://github.com/YusTech123/WebAppFinal/assets/115075205/e875557e-56d5-439a-bfd6-37bbdc736bb0)


Step 4. I’ve created 5 Model classes. My Project is based on a Supermarket. The 5 Model classes I’ve created are Customers.cs , Product.cs , Category.cs , Basket.cs , and Order.cs. The Models are the data and business logic. They contain the structure  and behaviour of the data in our application  

![Untitled (6)](https://github.com/YusTech123/WebAppFinal/assets/115075205/b6e9045f-33f0-4da7-a0de-f1390d80e492)


![Untitled (7)](https://github.com/YusTech123/WebAppFinal/assets/115075205/e0d0a8f8-5152-4fed-b17c-250dad749442)


Step 5: It’s time to create a DbContext class which will be used for Dependency injection. DbContext, which represents the database session in Entity Framework Core, is provided to the class from outside rather than being created within the class itself. This allows for better decoupling, testability, and flexibility in managing the database connection and operations within the application.  Additionally, Installed EntityFrameworkCore in Via Nuget Package Manager.  Installing the EntityFrameworkCore dependency provides functionality for my DbContext model to interact with a database using Entity Framework Core. This allows you to define your database schema using C# classes and manage database operations such as querying, inserting, updating, and deleting data more easily and efficiently.


![Untitled (8)](https://github.com/YusTech123/WebAppFinal/assets/115075205/17473abc-d8e2-4130-85e8-39286f986ad2)

Step 6 : In order to Register the context with Dependency injection. I’ve entered the following code in our Program.cs. Additionally, I’ll need to install Microsoft.EntityFrameworkCore.SqlServer. This be used for  interacting with Microsoft SQL Server databases. When you install this package as a dependency, it enables your DbContext model to work specifically with SQL Server databases, providing support for features and optimizations tailored to SQL Server. 

`builder.Services.AddDbContext<Context>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));`

![Untitled (9)](https://github.com/YusTech123/WebAppFinal/assets/115075205/e393b465-7dbe-44c7-88a1-7b9c6d47b585)


Step 7: I’m going to now add the Database Connection String Into my Appsettings.Json File: The purpose of this configuration is to provide the necessary information for the application to establish a connection to the database.  The Json syntax will look like this 

`{
"ConnectionStrings": {
"Connection": "Server=(localdb)\\MSSQLLocalDB;Database=Pickname;Trusted_Connection=True;"
}
}`

Step 8: It now time to add Migrations via the NuGetPackmanager Console.  However, Before doing this Install Microsoft Entity Framework Core Tools.

 Tools - NutGetPackage Manager - Package Manager Console 

![Untitled (10)](https://github.com/YusTech123/WebAppFinal/assets/115075205/6352fe7d-190a-4d67-861c-bca71cb69259)


Enter the following Commands into the console 

(This will create a class name InitalCreate in which code to create tables for my models will be present)

Update-Database
(This will create a Database based on information From initialCreateClass) 

Add-Migration InitialCreate

A Folder called Migrations will be created 

![Untitled (11)](https://github.com/YusTech123/WebAppFinal/assets/115075205/7efda677-5f7e-43ac-9133-5bd56b7c83ac)


The Next Command is Update-Database. 

In My Project I was getting the Following Error message. This was preventing me from creating my Database. In order to fix this you’ll need to make change on your Project SDk File

![Untitled (14)](https://github.com/YusTech123/WebAppFinal/assets/115075205/c939a610-9f88-48d4-b2a8-5bdd88089db6)


You’ll need to change the following from True to False. In order to fix the issue. 
![Untitled (12)](https://github.com/YusTech123/WebAppFinal/assets/115075205/e01f5267-9ed5-4248-8799-d109298bff16)


Step 9: If successful, You should get this Database appearing on your local machine.

![Untitled (15)](https://github.com/YusTech123/WebAppFinal/assets/115075205/47c5ad7d-fc9c-42e4-8168-ae1797880e3c)


Step 10: Now, I’ll need to create the Api controllers for the my Models. the API controllers typically handle incoming HTTP requests and generate appropriate HTTP responses. These controllers are responsible for processing data, interacting with my Database Server. 

  Controllers Folder - right Click and select Add  and click on Controller.


![Untitled (16)](https://github.com/YusTech123/WebAppFinal/assets/115075205/76c69135-8491-484d-9642-3136fee2ce02)

Step 11: Once, you're on this page. Select the following. Under common click on Api and Select Api controller with actions, Using Entity Framework. This will Auto generate a Api Controller class using my Model class and Dbcontext. This will allow me to implement CRUD functions into my Application. 

![Untitled (17)](https://github.com/YusTech123/WebAppFinal/assets/115075205/4749442b-8b44-4984-ad10-9442548b3292)


![Untitled (18)](https://github.com/YusTech123/WebAppFinal/assets/115075205/6e864e53-2874-44b4-97d4-9f3a9de9b244)


Step 12: Once, you’ve generated all your controllers. You should have the following in your controllers folder. 


![Untitled (20)](https://github.com/YusTech123/WebAppFinal/assets/115075205/c1a07801-88b2-4070-93c9-c788703fff93)

Step 13: In this Step i will be adding a Identity support into my Application to allow things like user accounts,Sign up, Sign in and Sign out. I start of by Installing the following Framework Microsoft.AspNetCore.Identity.EntityFrameworkCore. Once this has been installed. I’ll add the following code to my Dbcontext and change it from `public class SupermarketContext : DbContext`  to `public class SchoolContext : IdentityDbContext<IdentityUser>`. Additionally, Adding the Following to the top of my Dbcontext.cs. 

`using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;`

![Untitled (21)](https://github.com/YusTech123/WebAppFinal/assets/115075205/5f2f307a-341a-4fdd-a13f-a150e43362b0)

Step 14: In my Program.cs I need to add another dependency injection. 

`builder.Services.AddIdentity<IdentityUser, IdentityRole>()
.AddEntityFrameworkStores<SchoolContext>().AddDefaultTokenProviders();`
This is necessary for setting up user authentication, authorization, and management functionality within an [ASP.NET](http://asp.net/) Core application. Once, I’ve added this to my Program.cs I need to add the `using Microsoft.AspNetCore.Identity;`   

![Untitled (22)](https://github.com/YusTech123/WebAppFinal/assets/115075205/ca41216e-ff85-4a97-b1af-67c7d58144d0)


Step 15: In my Migration folder i will created a class  called IdentityAdded. Using the following Command `Add-Migration IdentityAdded`  

I’ll go to tools -> NuGet package manager -> Package manager console
And type in `Add-Migration IdentityAdded`  

If it is successful, you will see a change in migrations
folder.

![Untitled (23)](https://github.com/YusTech123/WebAppFinal/assets/115075205/f90f4e18-ddd3-4309-b394-89fd187b34de)


  
Now, I’ll enter the Command `Update-Database.`  if look at the database now, new tables have been added

![Untitled (24)](https://github.com/YusTech123/WebAppFinal/assets/115075205/5d5a715d-49c1-4bfe-aa59-fe9d3c16e54d)


Step 16:  I’ll need to download a dependency called Mailkit.  Go to the tools -> NuGet Package manager -> Manage NuGet packages for solution and browse and install the package MailKit. 

Step 17: I’ll now need to create the sign in functions. by creating a Authentication class in my Models folder. 

![Untitled (25)](https://github.com/YusTech123/WebAppFinal/assets/115075205/f075899d-ce4f-4795-884d-8c0889ecfe74)


Step 18: I’ll create a folder name services in which it will allow me to create a Emailservice class and a email settings.class. It will look like the following image. 

![Untitled (26)](https://github.com/YusTech123/WebAppFinal/assets/115075205/4bac5b65-e588-47a0-8e67-4f1c5a3e61e1)

![Untitled (27)](https://github.com/YusTech123/WebAppFinal/assets/115075205/ba4f72d9-1a87-491d-b9e3-a9b5a4428560)


Step 19: Now it’s time for me to build the AccountController.cs.  by right clicking the controller folder and add new file. Make Sure to select the following 

![Untitled (28)](https://github.com/YusTech123/WebAppFinal/assets/115075205/57e354d1-276f-444b-8246-cb3f0d1b10c0)


Step 20:  I need to now register my email service in my Program.cs.
`builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));
builder.Services.AddScoped<EmailService>();`

![Untitled (29)](https://github.com/YusTech123/WebAppFinal/assets/115075205/20fd3302-22de-4f3f-b66a-46c0fec12cca)


Step 21: Now I need to mention the configuration via my Json file 

`"EmailSettings": {
"SmtpServer": "[smtp.gmail.com](http://smtp.gmail.com/)",//only valid for gmail
"SmtpPort": 587,
"SmtpUsername": "[yourgmailaccount@gmail.com](mailto:yourgmailaccount@gmail.com)",//create a testing gmail account
"SmtpPassword": "your gmail app password"//use one time generated app password
},`

Important Side not: I kept getting errors like this in my program when running it “**No operations defined in spec!”**   

This  was due to me not inputting two very important statements. Make sure to add these to your Program.cs and test your API endpoints. 

`builder.Services.AddControllers();`   `app.MapControllers();.`

Step 22:  I’ve created a random email account to test that this is working as it will send a verification email to my dummy email. 

Test 1: 

![Untitled (30)](https://github.com/YusTech123/WebAppFinal/assets/115075205/8a067340-ede5-4f46-bc0c-841e12a816aa)


Result:
![Untitled (31)](https://github.com/YusTech123/WebAppFinal/assets/115075205/8fb942de-3499-4df8-a97f-ff33e7909d26)

-----------------------------------------------------------------------------------------------

Step 23: In this Step I will work towards implementing a JWT token. 

A JSON Web Token (JWT) is a compact and self-contained way to securely transmit information between parties as a JSON object. It consists of three parts: a header, a payload, and a signature. JWTs are commonly used for authentication and authorization in web applications. First I will need to download a Dependency called: Microsoft.AspNetCore.Authentication.JwtBearer

Tools - Nuget Package Manager - Manage Nutget Package Solution.

![Untitled (32)](https://github.com/YusTech123/WebAppFinal/assets/115075205/59813c01-2a61-434e-941a-6a4eb8fbcd32)


Step 24:  In my Program.cs I will need to enter the following code. 

builder.Services.AddScoped<RolesController>();

```
        builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["Jwt:Issuer"],
                    ValidAudience = builder.Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
                };
                });

```

Step 25: I’ll now need to add 

"Jwt": {

```
"Key": "your_secret_key_here",//could be any key e.g. j38jde9je9@#$%^&*

"Issuer": "your_issuer_here",//e.g. ‘<https://localhost:44300>’ port could be different in your case

"ExpireHours": 1

```

},
this configuration block helps manage the security and validity of JWTs used within the application, including specifying the secret key for signing tokens, identifying the issuer of the tokens, and setting an expiration time to control token validity.

Step 26: I’ve had to Update my code in my AccountController to allow me to create An admin and User account. This is for Role base access control. 

![Untitled (33)](https://github.com/YusTech123/WebAppFinal/assets/115075205/e84de5c0-01b8-4675-89f3-065402491184)


Step 27: I will now create two more Classess in my Models folder. that will contain the following.

public class AssignRoleModel
{
public string UserId { get; set; }
public string RoleName { get; set; }
}

public class UpdateRoleModel
{
public string RoleId { get; set; }
public string NewRoleName { get; set; }
}

![Untitled (34)](https://github.com/YusTech123/WebAppFinal/assets/115075205/fe115c36-8bf4-44f1-b061-5e955f2afd4c)


Step 28: I've now developed a RolesController.cs that facilitates CRUD operations for assigning admin roles. This will allow for Role base access control.

![Untitled (35)](https://github.com/YusTech123/WebAppFinal/assets/115075205/af6439cc-ef1c-4e83-8d57-1a7f23384a14)


Step 29: I will now Use Postman in order to Authorize who can use my system.   

Test for Verifying successful login and log out


![Untitled (36)](https://github.com/YusTech123/WebAppFinal/assets/115075205/ca2c2b4b-b037-4d64-bf60-b24f31980a9d)



![Untitled (37)](https://github.com/YusTech123/WebAppFinal/assets/115075205/b8678183-7763-423d-b3a0-03b83fa058ad)


-----------------------------------------------------------------------------------------------
Azure Web hosting Setup.

Step 1: Setup a Resource group and Within the Resource group create a Azure SQL database and SQL Server. Once, the SQL server is Set up copy the server name: Something[.database.windows.net].

This is located in Properties - Server Name.

![Untitled (38)](https://github.com/YusTech123/WebAppFinal/assets/115075205/98340438-81b4-4200-8573-6e7613082e7e)


Step 2: Go to Microsoft SQL Server Management Studio and connect to your SQL Server. The following Prompt will appear. You will now need to set up a connection to allow your device to connect to Azure.

![Untitled (40)](https://github.com/YusTech123/WebAppFinal/assets/115075205/fee9ea52-c2bb-42a3-b42a-8caddce85c07)


![Untitled (41)](https://github.com/YusTech123/WebAppFinal/assets/115075205/ab959ddd-84c8-40bf-91af-648156de3ad7)


Step 3:  Go to your Networking page located in the following and Create a Firewall Rule to allow your Client IP Address. This will allow connection to your Database. Make sure to click Save.

![Untitled (42)](https://github.com/YusTech123/WebAppFinal/assets/115075205/c078b1be-8b19-442f-a1ba-5e4d63f3da3c)


![Untitled (43)](https://github.com/YusTech123/WebAppFinal/assets/115075205/40975352-c33a-447d-8dd6-ffd87bd0dc89)


Step 4: Now that my Ip address is allowed it should automatically connect and look like this 

![Untitled (44)](https://github.com/YusTech123/WebAppFinal/assets/115075205/90ed309d-cb80-420b-9d12-8ede8a51bbfb)


Step 5: Now you will need to export your Database to your Azure SQL database. Click on your local Db. Right click and select tasks - Click Export Data-Tier Application .

![Untitled (45)](https://github.com/YusTech123/WebAppFinal/assets/115075205/bc3c760e-c53b-4e3a-93e1-ccffcb0f24eb)


Step 6 :  It’s now time to save our current database into a bacpac File. Select next on the introduction page. Go to Save local disk and select browse. select what disk you want to save the file onto. 

![Untitled (46)](https://github.com/YusTech123/WebAppFinal/assets/115075205/84faea86-f17f-4c62-9495-b52718beff64)


Step 7: Once you’ve selected the disk and given it a Name. I would suggest naming it the Database name to avoid conflict or issues. on settings click on Advanced and select the drop down menu to ensure that your database tables are all correct and being saved. Just press Next and allow it to export all the data from the database. it should look like this.

![Untitled (47)](https://github.com/YusTech123/WebAppFinal/assets/115075205/dac3491d-73a5-4e7c-912b-8328254eb941)

![Untitled (48)](https://github.com/YusTech123/WebAppFinal/assets/115075205/231dd467-2873-4895-a003-f2f8ac108fcf)

Step 8: It’s now time for me to Import the LocalDatabase to my Azure SQL.  Right click on Databases - Select Import Data-tier to Application 

![Untitled (49)](https://github.com/YusTech123/WebAppFinal/assets/115075205/6fd95c88-f475-4594-9ccc-2be312d48ab8)


Step 9 : Similar to the Export Process. We now need to select the Specific BACPAC file we saved via the following. Select Browse and Locate the BACPAC File.

![Untitled (50)](https://github.com/YusTech123/WebAppFinal/assets/115075205/f59fbd0f-2419-4810-bb57-032e5800712d)


Step 10: This Part you’ll need to select the size(Storage) of the database. 

![Untitled (51)](https://github.com/YusTech123/WebAppFinal/assets/115075205/73f98dd7-883c-4ca6-804e-696f1aefbf6a)



Step 11: Make sure you’re happy with the Summary and select finish to allow it to build the Database.  The End result will look like this. 

![Untitled (52)](https://github.com/YusTech123/WebAppFinal/assets/115075205/470910a3-5dff-4317-b9a0-09dbd8ceed8c)


Step 12: run a Query on Editor and test to see if everything on your database is working. Additionally, Add the connection string from your SQL database onto your Application.Json file

![Untitled (53)](https://github.com/YusTech123/WebAppFinal/assets/115075205/e354400a-cab8-4eec-a852-02c2556d282b)




-----------------------------------------------------------------------------------------------

Building a Linux Server on Azure to Host My Application.

Step 1: I’ve already created my Linux machine but these are the following resources you would need to apply onto your ubuntu server.

![Untitled (55)](https://github.com/YusTech123/WebAppFinal/assets/115075205/91109a98-1673-4db9-8b68-837e97404eb8)


Step 2:  you’ll need to go to command prompt and paste the Ssh link:ssh -i ~/.ssh/id_rsa.pem [AdminWebApp@](mailto:AdminWebApp@20.26.124.164)withIP address to access the Linux machine. enter the login detail that you set up for your machine and ensure to download your PEM file to allow you SSh connection as the Pem file works as a Token. 

![Untitled (56)](https://github.com/YusTech123/WebAppFinal/assets/115075205/e9a74f08-b333-407a-8d1f-09e30d08c141)


Step 3: I've already installed the dotnet on my Unbuntu server. However, this can be done by doing the following. https://learn.microsoft.com/en-us/dotnet/core/install/linux-scripted-manual#manual-install

you can download the script with `wget`:

```
wget https://dot.net/v1/dotnet-install.sh -O dotnet-install.sh

```

Before running this script, make sure you grant permission for this script to run as an executable:

```
chmod +x ./dotnet-install.sh

```

The script defaults to installing the latest [long term support (LTS)](https://dotnet.microsoft.com/platform/support/policy/dotnet-core) SDK version, which is .NET 8. To install the latest release, which might not be an (LTS) version, use the `--version latest` parameter.

```
./dotnet-install.sh --version latest

```

To install .NET Runtime instead of the SDK, use the `--runtime` parameter.

```
./dotnet-install.sh --version latest --runtime aspnetcore

```

You can install a specific major version with the `--channel` parameter to indicate the specific version. The following command installs .NET 8.0 SDK.

```
./dotnet-install.sh --channel 8.0
```

4. in order to allow your machine to Run dotnet. You’ll need to do the following. on this page you will need to run this 

```
DOTNET_FILE=dotnet-sdk-8.0.100-linux-x64.tar.gz
export DOTNET_ROOT=$(pwd)/.dotnet

mkdir -p "$DOTNET_ROOT" && tar zxf "$DOTNET_FILE" -C "$DOTNET_ROOT"

export PATH=$PATH:$DOTNET_ROOT:$DOTNET_ROOT/tools

```

```
export DOTNET_ROOT=$HOME/.dotnet
```

![Untitled (57)](https://github.com/YusTech123/WebAppFinal/assets/115075205/f3a2ad28-768a-4745-957d-233ab3ace0a3)


Step 5:  Type the command ls and cd  into your project/. Once this is done you can run Dotnet and it should build your application and run it on virtual Machine. 

![Untitled (58)](https://github.com/YusTech123/WebAppFinal/assets/115075205/6e061ba9-78ef-44a9-9a4b-50e855bd56c4)


![Untitled (59)](https://github.com/YusTech123/WebAppFinal/assets/115075205/c4c05f7c-83e3-4a03-ac16-eea9895bf800)


Step 6 : Ensure successful access to your Restful API by creating an inbound rule on your database and an outbound rule on your virtual machine for secure communication. Once, successful you should be able to access your Restful API from your web server.

![Untitled (60)](https://github.com/YusTech123/WebAppFinal/assets/115075205/eb1cac0a-a489-48cb-9b37-5b3bf78f6c1a)



