<br>
<p align="center">
  <u><big>|| <b>US Park API</b> ||</big></u>
  <br>
  <em>Epicodus - C# and .NET - Building an API - Code Review</em>
  <br>
  ___________________________
  <br>
  <strong>Jessi B</strong>
  <br>
  <small>March 2022</small>
</p>

------------------------------
### <u>Table of Contents</u>
* <a href="#-description">Description</a>
* <a href="#-technologies-used">Technologies Used</a>
* <a href="#-setup-&-installation">Setup & Installation</a>
* <a href="#-known-bugs">Known Bugs</a>
* <a href="#-contact">Contact</a>
* <a href="#-license">License</a>
------------------------------
### Description
An API that functions as a US Parks archive for national, state and city parks. It utilizes RESTful principles and version control. The user is able to see the in-use version of the API when using Postman.
#
### Technologies Used
* [Visual Studio Code](https://code.visualstudio.com/)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* [MySQL 8.0.20 for Linux](https://dev.mysql.com/)
* [Entity Framework Core 2.2.6](https://docs.microsoft.com/en-us/ef/core/)
* [Swagger - NSwag 13.3.0](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio)
* [Postman](postman.com)
#
### Setup & Installation
* Download Microsoft .NET Core: [Mac users click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) OR [Windows users click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer)
* Install dotnet script: Enter the command ``dotnet tool install -g dotnet-script`` in terminal
* Install MySQL Workbench: [Download and install the appropriate version of MySQL Workbench](https://dev.mysql.com/downloads/workbench/)
* Install Postman: (Optional) [Download and install Postman](https://www.postman.com/downloads/)
* Clone Repo: In your terminal, navigate to your desktop or other desired location and enter `git clone https://github.com/jessb-epicodus/USParkAPI.Solution.git`
* Add Required Packages: Navigate to the top level of the project directory called _USParkAPI_ & enter each of the following commands:
```
  dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0
  dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2
  dotnet add package Microsoft.EntityFrameworkCore.Design -v 5.0.0
  dotnet add USParkAPI.csproj package Swashbuckle.AspNetCore -v 6.2.3
  dotnet add package Microsoft.AspNetCore.Mvc.Versioning --version 5.0.0
```
* Protect Your MySQL Password: Enter `touch .gitignore` & `touch appsettings.json` in the command line
* Add the following code to _appsettings.json_ & update the server, port, and user id & password as necessary:
  ```
  {
    "Logging": {
      "LogLevel": {
        "Default": "Information",
        "Microsoft": "Warning",
        "Microsoft.Hosting.Lifetime": "Information"
      }
    },
    "AllowedHosts": "*",
    "ConnectionStrings": {
      "DefaultConnection": "Server=localhost;Port=3306;database=US_park;uid=root;pwd=YOUR PASSWORD;"
    }
  }
  ```
* Add _*/appsettings.json_ to _.gitignore_
* Update Database: Enter `dotnet ef migrations add <MigrationName>` & `dotnet ef database update` in the terminal
* Install Dependecies: Enter `dotnet restore` in your terminal
* Try Out This Web App: Enter `dotnet run` in the command line and either,
  * Navigte to _http://localhost:5000/_ in Postman - or -
  * Navigate to _http://localhost:5000/swagger_ in your browser
* HTTP Requests
  * GET /api/parks
  * POST /api/parks
  * GET /api/parks/{id}
  * PUT /api/parks/{id}
  * DELETE /api/parks/{id}
* Endpoints: Use base URL: _https://localhost:5000_
* Example Query: _https://localhost:5000/api/parks_
* Sample JSON Response:
```
  {
    "parkId": 5,
    "name": "Molalla River Recreation Area",
    "city": "Molalla",
    "state": "Oregon",
    "managedBy": "Bureau of Land Management",
    "activities": "fishing",
    "amenities": "restrooms",
    "ada": true
  }
```
* ##### Path Parameters 
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| name | string | none | required | Return matches by name |
| city | string | none | required | Return matches by city |
| state | string | none | required | Return matches by state |
| managedBy | string | none | required | Return matches by who manages the park |
| activities | string | none | required | Return matches by activities |
| amenities | string | none | required | Return matches by amenities |
| ada | bool | none | required | Return matches if true |
* Example Query: _https://localhost:5000/api/parks?state=oregon&state=portland_
* Sample JSON Response
```
  {
    "parkId": 5,
    "name": "Forest Park",
    "city": "Portland",
    "state": "Oregon",
    "managedBy": "Portland Parks and Recreation",
    "activities": "trail running",
    "amenities": "",
    "ada": true
  }
```
#
### Known Bugs
This is not a real API, which is the greatest shame of all.
#
### License
Copyright (c)  _Mar 2022_  _Jessi B_
#
### Contact
_If you run into any issues or have questions, ideas or concerns or wish to make a contribution to the code see contact information below._
* Jessi B <jessb.epicodus@gmail.com>
------------------------------

<center><a href="#">Return to Top</a></center>