# Hotel Booking Application

## Overview
The Hotel Booking Application is a .NET 9-based system designed to manage hotel room bookings. It provides functionalities to view, add, update, and delete room, booking, customer, and invoice information. The application is built using C# 13.0 and follows a modular architecture with clear separation of concerns.

## Features
- **Room Management**: View all rooms, view deleted rooms, and view details of a specific room.
- **Booking Management**: View all active bookings, view deleted bookings, and view details of a specific booking.
- **Customer Management**: View all customers, add new customers, and update customer details.
- **Invoice Management**: View all invoices, generate new invoices, and update invoice details.
- **Validation**: Input validation for room, booking, customer, and invoice details.
- **Display**: User-friendly display of information using Spectre.Console.

## Architecture
The application is organized into several key components:

- **Controllers**: Handle the business logic and user interactions.
- **Interfaces**: Define the contracts for services and controllers.
- **Models**: Represent the data structures used in the application.
- **Services**: Provide data access and business logic.
- **Utilities**: Helper classes for validation, display, and other common tasks.

## Prerequisites
- .NET 9 SDK
- Visual Studio 2022
- SQL Server Management Studio
- Autofac (for dependency injection)

## Installation
1. Clone the repository:
2. Open the solution in Visual Studio 2022.

## Database Setup
The application uses a code-first approach for the database. When you run the application for the first time, the database will be created automatically.

## Running the Application
1. Build the solution in Visual Studio.
2. Run the application from Visual Studio.

## Usage
- Use the console interface to navigate through the options for managing rooms, bookings, customers, and invoices.
- Follow the prompts to view, add, update, or delete room, booking, customer, and invoice information.

## Dependency Injection
The application uses Autofac for dependency injection. The dependencies are configured in the `Program` class or the main entry point of the application.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License
This project is licensed under the MIT License.

## Acknowledgements
- [Spectre.Console](https://spectreconsole.net/) for the console UI library.
- [Autofac](https://autofac.org/) for the dependency injection framework.



