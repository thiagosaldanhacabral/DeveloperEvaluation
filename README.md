# DeveloperEvaluation

## Overview

DeveloperEvaluation is a web application built with .NET 8 and C# 12.0. It provides a robust API for managing products, including features such as logging, health checks, authentication, and more.

## Table of Contents

- [Getting Started](#getting-started)
- [Prerequisites](#prerequisites)
- [Installation](#installation)
- [Running the Application](#running-the-application)
- [Running Tests](#running-tests)
- [Project Structure](#project-structure)
- [Technologies Used](#technologies-used)
- [Contributing](#contributing)
- [License](#license)

## Getting Started

These instructions will help you set up and run the DeveloperEvaluation application on your local machine for development and testing purposes.

## Prerequisites

- .NET 8 SDK
- PostgreSQL
- Redis
- Visual Studio 2022

## Installation

1. Clone the repository:


2. Set up the database:
    - Create a PostgreSQL database.
    - Update the connection string in `src/DeveloperEvaluation.WebApi/appsettings.json`:
      

3. Set up Redis:
    - Ensure Redis is running on your local machine or update the configuration in `src/DeveloperEvaluation.WebApi/appsettings.json` if necessary.

## Running the Application

1. Open the solution in Visual Studio 2022.
2. Build the solution to restore the dependencies.
3. Run the application by pressing `F5` or using the `dotnet run` command in the `src/DeveloperEvaluation.WebApi` directory:


## Running Tests

1. Navigate to the `tests/DeveloperEvaluation.Unit` directory.
2. Run the tests using the following command:



## Project Structure

- `src/DeveloperEvaluation.WebApi`: Contains the main web API project.
- `src/DeveloperEvaluation.Application`: Contains the application layer with business logic.
- `src/DeveloperEvaluation.Domain`: Contains domain entities and interfaces.
- `src/DeveloperEvaluation.ORM`: Contains the ORM configuration and migrations.
- `src/DeveloperEvaluation.Common`: Contains common utilities and extensions.
- `tests/DeveloperEvaluation.Unit`: Contains unit tests for the application.

## Technologies Used

- .NET 8
- C# 12.0
- Entity Framework Core
- MediatR
- AutoMapper
- Serilog
- FluentValidation
- xUnit
- Redis
- PostgreSQL

## Contributing

Contributions are welcome! Please read the [CONTRIBUTING.md](CONTRIBUTING.md) for guidelines on how to contribute to this project.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for details.
