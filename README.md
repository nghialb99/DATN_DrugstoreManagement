# DrugstoreManagement

# ASP.NET Core with .NET6 project from NghiaLe
## Technologies
- ASP.NET Core with .NET6
- EntityFrameworkCore 6.0.5
## Install Tools
- .NET 6 SDK
- Visual Studio 2022
- SQL Server 2019

## How to configure and run
- Download or clone code from Github: git clone github.com/nghialb99/DATN_DrugstoreManagement/tree/develop
- Open solution DATN_DrugstoreManagement.sln in Visual Studio 2022
- Set startup project is DrugstoreManagement.Data
- Change connection string in Appsetting.json in DrugstoreManagement.Data project
- Open Tools --> Nuget Package Manager -->  Package Manager Console in Visual Studio
- Run Update-database and Enter.
- Change database connection in appsettings.Development.json in DrugstoreManagement.BackendApi project.
- You need to change 2 projects to self-host profile.
- Set multiple run project: Right click to Solution and choose Properties and set Multiple Project, choose Start for 2 Projects: BackendApi, WebApp.
- Choose profile to run or press F5
## WebApp template: https://startbootstrap.com/templates/sb-admin/ ; https://bootstrapmade.com/nice-admin-bootstrap-admin-html-template/
