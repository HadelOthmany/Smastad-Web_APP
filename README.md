# Småstad Web Application

Småstad Web Application is an ASP.NET Core MVC project developed as part of my studies in Computer Science.

The purpose of the application is to provide information about events in a municipality and allow authorized editors to manage event information.

## Features

- View upcoming events
- View detailed information about individual events
- Display event images
- Event categories
- Editor login
- Role-based authorization using ASP.NET Core Identity
- Add new events
- Form validation
- Database integration using Entity Framework Core
- Repository pattern for database access
- Responsive web interface

## Technologies

The project was developed using:

- C#
- ASP.NET Core MVC
- Entity Framework Core
- ASP.NET Core Identity
- SQL Server / LocalDB
- Razor Views
- HTML
- CSS
- Bootstrap
- JavaScript
- Visual Studio

## Application Structure

The application follows the MVC architecture:

```text
User
  ↓
Controller
  ↓
Model / Repository
  ↓
Database
  ↓
Controller
  ↓
View
  ↓
User
