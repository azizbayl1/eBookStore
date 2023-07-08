<h1 align="center">eBookStore</h1>

<p align="center">
  This is an online book store built using ASP.NET Core, C#, Entity Framework Core (EF Core), and Microsoft SQL Server (MSSQL). The project follows the principles of clean architecture and aims to provide a clean and maintainable codebase.
</p>

## Project Status

Please note that the eBookStore project is currently under development and there is still a long way to go before it is considered a complete and production-ready application. However, the project is actively being worked on and improvements are being made regularly.

## Technologies Used

The eBookStore project utilizes the following technologies:

- **ASP.NET Core:** A cross-platform framework for building web applications.
- **C#:** The primary programming language used in this project.
- **EF Core:** Entity Framework Core is an object-relational mapping (ORM) framework that provides an abstraction for interacting with databases.
- **MSSQL:** Microsoft SQL Server is used as the database management system for this project.

## Clean Architecture

The eBookStore project follows the principles of clean architecture, with the following layers:

- **Presentation Layer:** Handles the presentation logic and user interface of the application.
- **Application Layer:** Implements the application-specific use cases and orchestrates the interactions between the presentation, domain, and infrastructure layers.
- **Domain Layer:** Contains the core business logic, entities, and domain services of the application.
- **Persistence Layer:** Deals with data access and implements repositories and data mappers for persisting and retrieving data from the database.
- **Infrastructure Layer:** Provides implementations for external concerns, such as logging, caching, and external services.

## Getting Started

To get started with the eBookStore project, follow these steps:

1. Clone the repository: `git clone https://github.com/your-username/ebookstore.git`
2. Open the project in your preferred development environment.
3. Set up the database connection string in the `appsettings.json` file.
4. Build the solution to restore the required NuGet packages.
5. Run the database migrations to create the necessary database schema.
6. Start the application.

Please note that you may need to install the required dependencies and tools based on your development environment. Refer to the documentation of ASP.NET Core, EF Core, and MSSQL for more information.

## Contributing

Contributions to the eBookStore project are welcome! If you find any issues or have ideas for improvements, feel free to open an issue or submit a pull request. Please follow the existing code style and conventions to maintain consistency throughout the project.

---
Javad Azizbayli
