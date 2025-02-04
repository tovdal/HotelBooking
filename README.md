# Hotel Booking Application

## Overview
The Hotel Booking Application is a .NET 9-based system designed to manage hotel room bookings. It provides functionalities to view, add, update, and delete room and booking information. The application is built using C# 13.0 and follows a modular architecture with clear separation of concerns.

## Features
- **Room Management**: View all rooms, view deleted rooms, and view details of a specific room.
- **Booking Management**: View all active bookings, view deleted bookings, and view details of a specific booking.
- **Validation**: Input validation for room and booking details.
- **Display**: User-friendly display of information using Spectre.Console.

## Project Structure
The project is organized into several key components:

- **Controllers**: Handle the business logic and user interactions.
  - `RoomReadController`: Manages room-related operations.
  - `BookingReadController`: Manages booking-related operations.

- **Interfaces**: Define the contracts for services and controllers.
  - `IRoomRead`: Interface for room data operations.
  - `IBookingRead`: Interface for booking data operations.
  - `IRoomReadController`: Interface for room controller operations.
  - `IBookingReadController`: Interface for booking controller operations.

- **Models**: Represent the data structures used in the application.
  - `Room`: Represents a hotel room.
  - `Booking`: Represents a booking.

- **Services**: Provide data access and business logic.
  - `RoomService`: Handles room data operations.
  - `BookingService`: Handles booking data operations.

- **Utilities**: Helper classes for validation, display, and other common tasks.
  - `DisplayRoomInformation`: Utility for displaying room information.
  - `DisplayBookingInformation`: Utility for displaying booking information.
  - `ConsoleMessagePrinter`: Utility for printing messages to the console.
  - `ListHelper`: Utility for list operations.
  - `ValidatorRoom`: Utility for room validation.
  - `ValidatorBooking`: Utility for booking validation.

## Prerequisites
- .NET 9 SDK
- Visual Studio 2022
- SQL Server Management Studio
- Autofac (for dependency injection)

## Installation
1. Clone the repository:
   
2. Open the solution in Visual Studio 2022.
3. Set up the database using SQL Server Management Studio:
   - Create a new database for the application.
   - Run the provided SQL scripts to set up the necessary tables and initial data.

## Running the Application
1. Build the solution in Visual Studio.
2. Run the application from Visual Studio.

## Usage
- Use the console interface to navigate through the options for managing rooms and bookings.
- Follow the prompts to view, add, update, or delete room and booking information.

## Dependency Injection
The application uses Autofac for dependency injection. The dependencies are configured in the `Startup` class.

## Contributing
Contributions are welcome! Please fork the repository and submit a pull request with your changes.

## License
This project is licensed under the MIT License.

## Acknowledgements
- [Spectre.Console](https://spectreconsole.net/) for the console UI library.
- [Autofac](https://autofac.org/) for the dependency injection framework.

