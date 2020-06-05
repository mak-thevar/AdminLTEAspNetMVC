
# AdminLTEAspNetMVC
Free admin dashboard template based on https://adminlte.io in [Asp.net MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)

## Table of Contents
- [Installation](#installation)
- [Features](#features)
- [Screenshots](#Screenshots)



## Installation
#### Pre-requisites : Nodejs, Visual Studio 2015 or higher.
- Open the solution file 'AspMVCAdminLTE.sln' directly in Visual Studio
- Now Build the project, initially the project will take longer time to build because it will download all the npm packages and compile/minify the js and css respectively.



## Features
- Uses [Owin](https://docs.microsoft.com/en-us/aspnet/aspnet/overview/owin-and-katana/owin-startup-class-detection) based startup class.
- Web API is configured and uses [Token based authentication](https://www.c-sharpcorner.com/UploadFile/ff2f08/token-based-authentication-using-Asp-Net-web-api-owin-and-i/).
- Can be easily customized to use [external authentication](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/external-authentication-services) services like Google, Facebook, etc.
- [Autofac](https://autofaccn.readthedocs.io/en/latest/getting-started/)  is configured as a dependency injection.
-  [Entity framework 6](https://docs.microsoft.com/en-us/ef/ef6/) with basic User entity and the authentication service is configured.
- Follows [Repository pattern](https://deviq.com/repository-pattern/) for the database operations.
- Custom HTML helpers has been added to support this specific template. Will be adding more HTML helpers in the future releases.


## Screenshots
![AadminLTE](https://i.imgur.com/mHSXd4P.png)

![AadminLTEASP.NET](https://i.imgur.com/50ZTcKk.gif)

![LoginAPI Postman](https://i.imgur.com/uREBifI.png)

