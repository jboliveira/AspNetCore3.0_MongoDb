# [PoC] ASP.NET Core WebAPI 3.0 with MongoDB #

[![Actions Status](https://github.com/jboliveira/AspNetCore3.0_MongoDb/workflows/Build/badge.svg)](https://github.com/jboliveira/AspNetCore3.0_MongoDb/actions)
![GitHub repo size](https://img.shields.io/github/repo-size/jboliveira/AspNetCore3.0_MongoDb.svg)
![GitHub last commit](https://img.shields.io/github/last-commit/jboliveira/AspNetCore3.0_MongoDb.svg)

## Tech Stack ##

- Visual Studio 2019 (Mac/Win)
- .NET Core v3.0.0 [3.0.100]
- MongoDB
- Docker

## Installing and Running via Docker Compose ##

```sh
    #Clone Git Repository
    git clone git@github.com:jboliveira/AspNetCore3.0_MongoDb.git

    #Access Project Root Folder
    cd AspNetCore3.0_MongoDb
    
    #Build and Run
    docker-compose -f docker-compose.yml up --build

    #Access through address:
    https://localhost:5000/swagger
```

## Installing and Running via .NET CLI ##

> Important: Install and run MongoDB. For more information, [click here](https://docs.mongodb.com/manual/administration/install-community/).

```sh
    #Clone Git Repository
    git clone git@github.com:jboliveira/AspNetCore3.0_MongoDb.git

    #Access Project Root Folder
    cd AspNetCore3.0_MongoDb/src/SampleApi
    
    #Build and Run
    dotnet restore
    dotnet build
    dotnet run

    #Access through address:
    https://localhost:5000/swagger
```
