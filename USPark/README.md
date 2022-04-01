<br>
<p align="center">
  <u><big>|| <b>US Parks API</b> ||</big></u>
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
* <a href="#-known-bugs">Known Bugs</a>
* <a href="#-technologies-used">Technologies Used</a>
* <a href="#-getting-started">Setup & Installation Requirements</a>
    * <a href="#-prerequisites">Prerequisites</a>
    * <a href="#-setup-and-use">Setup and Use</a>
* <a href="#-api-documentation">API Documentation</a>
* <a href="#-contributors">Auxiliary</a>
    * <a href="#-contributors">Contributors</a>
    * <a href="#-contact-and-support">Contact</a>
    * <a href="#-license">License</a>
    * <a href="#-acknowledgements">Acknowledgements</a>
    
------------------------------
#
### Description
An API that functions as a US Parks archive for national, state and city parks. It utilizes RESTful principles, version control, pagination, and has integrated authentication to keep the API Read-Only for all users except administrators. The user is able to see the in-use version of the API when using Postman.
#
### Known Bugs

* This is not a real API, which is the greatest shame of all.
#
### Technologies Used
* [Visual Studio Code](https://code.visualstudio.com/)
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/)
* [ASP.NET Core MVC](https://docs.microsoft.com/en-us/aspnet/core/mvc/overview?view=aspnetcore-3.1)
* [MySQL 8.0.20 for Linux](https://dev.mysql.com/)
* [Entity Framework Core 2.2.6](https://docs.microsoft.com/en-us/ef/core/)
* [Swagger - NSwag 13.3.0](https://docs.microsoft.com/en-us/aspnet/core/tutorials/getting-started-with-nswag?view=aspnetcore-3.1&tabs=visual-studio)
* [Postman](postman.com)

<!-- ### Preview -->

------------------------------
#
## Setup/Installation Requirements
* Download Microsoft .NET Core: [Mac users click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.106-macos-x64-installer) OR [Windows users click here](https://dotnet.microsoft.com/download/thank-you/dotnet-sdk-2.2.203-windows-x64-installer)
* Install dotnet script: Enter the command ``dotnet tool install -g dotnet-script`` in terminal
* Install MySQL Workbench: [Download and install the appropriate version of MySQL Workbench](https://dev.mysql.com/downloads/workbench/)
* Install Postman: (Optional) [Download and install Postman](https://www.postman.com/downloads/)
* Clone Repo: In your terminal, navigate to your desktop or other desired location and enter `git clone https://github.com/jessb-epicodus/USParkAPI.git`
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

### Using Swagger Documentation 
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
* The token will be generated in the response. Copy and paste it as the Token paramenter in the Authorization tab.

* Example Query: _https://localhost:5000/api/parks/?name=Yellowstone_

To use default, _don't include_ `limit` and `start` or set them equal to zero.

..........................................................................................

* Endpoints: Use base URL: `https://localhost:5000`
* HTTP Request Structure
```
GET /api/{component}
POST /api/{component}
GET /api/{component}/{id}
PUT /api/{component}/{id}
DELETE /api/{component}/{id}
```
* Example Query: _https://localhost:5000/api/parks/131_
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
  },
```
..........................................................................................
#### HTTP Request
```
GET /api/bean
POST /api/bean
GET /api/bean/{id}
PUT /api/bean/{id}
DELETE /api/bean/{id}
```

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| name | string | none | false | Return matches by name.
| origin | string | none | false | Return any bean from a specific country or region of origin. |
| flavor | string | none | false | Return bean matches with a specific flavor profile. |

#### Example Query
```
https://localhost:5000/api/bean/?origin=brazil&flavor=robust
```

#### Sample JSON Response
```
{
    "Id": 114,
    "Name": "Café Saboroso",
    "Origin": "Brazil",
    "Flavor: "Sweet, Cherry, Robust"
}
```

..........................................................................................

### Beverages
Access information about popular coffee beverages.

#### HTTP Request
```
GET /api/beverage
POST /api/beverage
GET /api/beverage/{id}
PUT /api/beverage/{id}
DELETE /api/beverage/{id}
```

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| name | string | none | false | Return matches by name.
| temp | string | none | false | Return beverage matches with a specific served temperature. |
| topping | string | none | false | Return beverage matches with a specific topping. |
| year | int | none | false | Return beverage matches with a specific year of invention. |

#### Example Query
```
https://localhost:5000/api/beverage/?name=latte&temp=iced&year=1840
```

#### Sample JSON Response
```
{
    "Id": 33,
    "Name": "Iced Latte",
    "Temp": "Iced",
    "Topping: "Wipped Cream",
    "Year": 1840
}
```

..........................................................................................

### Recipes
Access recipes to recreate popular coffee beverages.

#### HTTP Request
```
GET /api/parks
POST /api/parks
GET /api/parks/{id}
PUT /api/parks/{id}
DELETE /api/parks/{id}
```

#### Path Parameters
| Parameter | Type | Default | Required | Description |
| :---: | :---: | :---: | :---: | --- |
| name | string | none | false | Return matches by name.
| ingredient | string | none | false | Return any parks with a specific ingredient. |

#### Example Query
```
https://localhost:5000/api/parks/?name=latte&ingredient=chocolate
```

#### Sample JSON Response
```
{
    "Id": 52,
    "Name": "Mocha Latte",
    "Ingredient": "Chocolate",
    "Recipe Text: "Make good coffee, add chocolate, crash after experiencing the awesome power of both.",
}
```

------------------------------

## Known Bugs

* No known issues

## License

Copyright (c) _Mar 2022_ _Jessi Baker_

## Contact

_If you run into any issues or have questions, ideas or concerns or wish to make a contribution to the code see contact information below._
* Jessi Baker <jessb.epicodus@gmail.com>
------------------------------

<center><a href="#">Return to Top</a></center>