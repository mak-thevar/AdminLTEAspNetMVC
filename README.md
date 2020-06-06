![Build Status](https://github.com/mak-thevar/AdminLTEAspNetMVC/workflows/Build%20the%20project/badge.svg)
[![Contributors][contributors-shield]][contributors-url]
[![Issues][issues-shield]][issues-url]
[![LinkedIn][linkedin-shield]][linkedin-url]

# AdminLTEAspNetMVC
Free admin dashboard template based on https://adminlte.io in [Asp.net MVC](https://dotnet.microsoft.com/apps/aspnet/mvc)

## Table of Contents
* [Getting Started](#getting-started)
* [Installation](#installation)
* [Features](#features)
* [Contributing](#contributing)
* [Screenshots](#Screenshots)
* [License](#license)
* [Contact](#contact)



## Getting Started
### Prerequisites
- [Nodejs](https://nodejs.org/en/download/)
- [Visual Studio](https://visualstudio.microsoft.com/)


## Installation

- Clone the repository
```sh
git clone https://github.com/mak-thevar/AdminLTEAspNetMVC.git
```
- Open the solution file 'AspMVCAdminLTE.sln' directly in Visual Studio
- If you want to connect to a database then open ```Configs/connectionStrings.config``` and add your connection string
- The appSettings can be found under ```Configs/appSettings.config```
- Now Build the project, initially the project will take longer time to build because it will download all the npm packages and compile/minify the js and css respectively.



## Features
- Uses [Owin](https://docs.microsoft.com/en-us/aspnet/aspnet/overview/owin-and-katana/owin-startup-class-detection) based startup class.
- Web API is configured and uses [Token based authentication](https://www.c-sharpcorner.com/UploadFile/ff2f08/token-based-authentication-using-Asp-Net-web-api-owin-and-i/).
- Can be easily customized to use [external authentication](https://docs.microsoft.com/en-us/aspnet/web-api/overview/security/external-authentication-services) services like Google, Facebook, etc.
- [Autofac](https://autofaccn.readthedocs.io/en/latest/getting-started/)  is configured as a dependency injection.
-  [Entity framework 6](https://docs.microsoft.com/en-us/ef/ef6/) with basic User entity and the authentication service is configured.
- Follows [Repository pattern](https://deviq.com/repository-pattern/) for the database operations.
- Custom HTML helpers has been added to support this specific template. Will be adding more HTML helpers in the future releases.

## Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the Project
2. Create your Feature Branch (`git checkout -b feature/AmazingFeature`)
3. Commit your Changes (`git commit -m 'Add some AmazingFeature'`)
4. Push to the Branch (`git push origin feature/AmazingFeature`)
5. Open a Pull Request


## Screenshots
![AadminLTE](https://i.imgur.com/mHSXd4P.png)

![AadminLTEASP.NET](https://i.imgur.com/50ZTcKk.gif)

![LoginAPI Postman](https://i.imgur.com/uREBifI.png)


<!-- LICENSE -->
## License

Distributed under the MIT License. See [`LICENSE`](https://github.com/mak-thevar/AdminLTEAspNetMVC/blob/master/LICENSE) for more information.

<!-- CONTACT -->
## Contact

Your Name - [Muthukumar Thevar](#) - mak.thevar@outlook.com

Project Link: [https://github.com/mak-thevar/AdminLTEAspNetMVC](https://github.com/mak-thevar/AdminLTEAspNetMVC)


[contributors-shield]: https://img.shields.io/github/contributors/mak-thevar/AdminLTEAspNetMVC.svg?style=flat-square
[contributors-url]: https://github.com/mak-thevar/AdminLTEAspNetMVC/graphs/contributors

[issues-shield]: https://img.shields.io/github/issues/mak-thevar/AdminLTEAspNetMVC.svg?style=flat-square
[issues-url]: https://github.com/mak-thevar/AdminLTEAspNetMVC/issues
[linkedin-shield]: https://img.shields.io/badge/-LinkedIn-black.svg?style=flat-square&logo=linkedin&colorB=555
[linkedin-url]: https://www.linkedin.com/in/mak11/
