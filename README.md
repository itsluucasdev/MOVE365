# M365

## Project Overview
The M365 solution is a modular application designed to provide scalable and maintainable software architecture. It consists of multiple projects, each responsible for a specific layer of the application.

## Solution Structure

### M365.Api
- **Purpose**: Acts as the entry point for the application, handling HTTP requests and routing them to the appropriate services.
- **Key Features**:
  - API versioning
  - Swagger documentation
  - Authentication and authorization
  - Health checks
  - OpenTelemetry for observability
- **Technologies**: ASP.NET Core, Serilog, OpenTelemetry, Swagger

### M365.Application
- **Purpose**: Contains the application logic and orchestrates the flow of data between the API and the domain layer.
- **Dependencies**: References the `M365.Domain` project.

### M365.Domain
- **Purpose**: Represents the core business logic and domain entities of the application.
- **Design**: Implements the domain-driven design principles.

### M365.Infrastructure
- **Purpose**: Provides infrastructure-related services such as authentication, logging, and telemetry.
- **Key Features**:
  - Custom authentication handlers
  - Extensions for logging, OpenTelemetry, and Swagger
- **Dependencies**: References the `M365.Application` and `M365.Domain` projects.
- **Technologies**: OpenTelemetry, Serilog, JWT Authentication

## Key Features
- Modular architecture for scalability and maintainability
- Comprehensive API documentation with Swagger
- Observability with OpenTelemetry
- Secure authentication and authorization mechanisms

## Setup Instructions
1. Clone the repository.
2. Build the solution using Visual Studio or the .NET CLI.
3. Run the `M365.Api` project to start the application.
4. Access the Swagger UI at `http://localhost:<port>/swagger` for API documentation.

## Contribution Guidelines
Contributions are welcome! Please follow the standard Git workflow:
1. Fork the repository.
2. Create a feature branch.
3. Commit your changes.
4. Submit a pull request.

