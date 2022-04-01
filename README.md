<br>
<p align="center">
  <u><big>|| <b>US Park API</b> ||</big></u>
  <br>
  _Epicodus - C# and .NET - Building an API - Code Review_
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
* <a href="#-prerequisites">Prerequisites</a>
* <a href="#-setup-and-use">Setup and Use</a>
* <a href="#-api-documentation">API Documentation</a>
* <a href="#-known-bugs">Known Bugs</a>
* <a href="#-contact">Contact</a>
* <a href="#-license">License</a>

------------------------------
#
### Description
An API that functions as a US Parks archive for national, state and city parks. It utilizes RESTful principles, version control, pagination, and has integrated authentication to keep the API Read-Only for all users except administrators. The user is able to see the in-use version of the API when using Postman.
#
### Technologies Used
* [Visual Studio Code](https://code.visualstudio.com/)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* [MySQL 8.0.20 for Linux](https://dev.mysql.com/)
* [Entity Framework Core 2.2.6](https://docs.microsoft.com/en-us/ef/core/)
<!-- * [Swagger - NSwag 13.3.0](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio) -->
* [Postman](postman.com)
------------------------------
#
## Setup & Installation
* Download Microsoft .NET Core: [Mac users click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) OR [Windows users click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer)
* Install dotnet script: Enter the command ``dotnet tool install -g dotnet-script`` in terminal
* Install MySQL Workbench: [Download and install the appropriate version of MySQL Workbench](https://dev.mysql.com/downloads/workbench/)
* Install Postman: (Optional) [Download and install Postman](https://www.postman.com/downloads/)
* Clone Repo: In your terminal, navigate to your desktop or other desired location and enter `git clone https://github.com/jessb-epicodus/USParkAPI.Solution.git`
* Add Required Packages: Navigate to the top level of the project directory called _USPark_ & enter each of the following commands.
** `dotnet add package Microsoft.EntityFrameworkCore -v 5.0.0`
** `dotnet add package Pomelo.EntityFrameworkCore.MySql -v 5.0.0-alpha.2  `
** `dotnet add package Microsoft.EntityFrameworkCore.Design -v 5.0.0`
** Protect Your MySQL Password: Enter `touch .gitignore` & `touch appsettings.json` in the command line
* Add the following code to _appsettings.json_ & update the server, port, and user id & password as necessary
  ```{
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
  }```
* Add _*/appsettings.json_ to _.gitignore_
* Update Database: Enter `dotnet ef migrations add <MigrationName>` & `dotnet ef database update` in the terminal
* Install Dependecies: Enter `dotnet restore` in your terminal
* Try Out This Web App: Enter `dotnet run` in the command line and navigte navigate to _http://localhost:5000/_ in Postman or your browser
------------------------------
#
## API Documentation
Explore the API endpoints in Postman or a browser. You will not be able to utilize authentication in a browser.
<!-- ### Using Swagger Documentation 
To explore the USPark API with NSwag, launch the project using `dotnet run` with the Terminal or Powershell, and input the following URL into your browser: `http://localhost:5000/swagger`

### Using the JSON Web Token
In order to be authorized to use the POST, PUT, DELETE functionality of the API, please authenticate yourself through Postman.
* Open Postman and create a POST request using the URL: `http://localhost:5000/api/users/authenticate`
* Add the following query to the request as raw data in the Body tab:
```
{
    "UserName": "CoffeeAdmin",
    "Password": "epicodus"
}
```
* The token will be generated in the response. Copy and paste it as the Token paramenter in the Authorization tab. -->

* Example Query: _https://localhost:5000/api/parks/?name=Yellowstone_

To use default, _don't include_ `limit` and `start` or set them equal to zero.

..........................................................................................

* Endpoints: Use base URL: _https://localhost:5000_
* Example Query: _https://localhost:5000/api/parks_
* Sample JSON Response
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
..........................................................................................
* HTTP Request
```
GET /api/parks
POST /api/parks
GET /api/parks/{id}
PUT /api/parks/{id}
DELETE /api/parks/{id}
```
* Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| name | string | none | false | Return matches by name
| city | string | none | false | Return matches by city
| state | string | none | false | Return matches by state
| managedBy | string | none | false | Return matches by who manages the park
| activities | string | none | false | Return matches by activities
| amenities | string | none | false | Return matches by amenities
| ada | bool | none | false | Return matches if ADA

* Example Query: _https://localhost:5000/api/parks?state=oregon&state=portland_
Sample JSON Response
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
------------------------------

## Known Bugs

* This is not a real API, which is the greatest shame of all.

## License

Copyright (c) _Mar 2022_ _Jessi B_

## Contact

_If you run into any issues or have questions, ideas or concerns or wish to make a contribution to the code see contact information below._
* Jessi B <jessb.epicodus@gmail.com>
------------------------------

<center><a href="#">Return to Top</a></center>