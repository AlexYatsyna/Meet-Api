# MeetUpApi

## About The Project
**MeetUpApi** is CRUD WEB API app for work with events (create, modify, delete, get) runs on .Net Core using EF Core.

## Table of contents

- [About the project](#about-the-project)
- [Built with](#built-with)
- [Short Overview of Project Components](#short-overview-of-actors)
- [Getting Started](#getting-started)



# Built With

* [.NET](https://docs.microsoft.com/en-us/dotnet/)
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)
* [MS SQL](https://docs.microsoft.com/en-us/sql/?view=sql-server-ver16)
* [AutoMapper](https://docs.automapper.org/en/stable/)
* [IdentityServer4](https://identityserver4.readthedocs.io/en/latest/)
* [Swagger](https://swagger.io/docs/)

# Short Overview of Project Components

## In this case, five kind of projects are implemented:
- ### The *MeetUp.Data* project is responsible for describing entities
- ### The *MeetUp.Logic* project is responsible for the logic of Get,Post,Put,Delete requests and their validation 
- ### The *MeetUp.Infrastructure* project is responsible for interacting with the database
- ### The *MeetUp.WebApi* project is responsible for the UI
- ### The *MeetUp.Identity* project is Authentication Server

As mentioned above, the **`MeetUp.Data`** project is responsible for describing the entities, and the **`MeetUp.Logic`** project is responsible for the logic of the Get,Post,Put,Delete requests and their validation. They make up the first layer of our project. **`MeetUp.Infrastructure`** is the second layer, which is responsible for database initialization, database context, etc. **`MeetUp.WebApi`** is a UI that uses Swagger to test WebApi and is the third layer.

#  Getting Started

### 1. Git clone
### 2. Install MS Sql Server
### 3. Configure 'appsettings.json' files (DbConnection string)
### 4. Start *MeetUp.WebApi* 

     p.s You can use *MeetUp.Identity* Server to add authorization




