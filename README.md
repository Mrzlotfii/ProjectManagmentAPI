***README***

Project Overview:
Description of the API, including functionality for managing projects and tasks.

Setup Instructions:
Prerequisites: Docker, .NET Core 8 SDK.
        Running the application:
            Clone the repository.
            Build the Docker containers.
docker-compose up --build

Access the API at http://localhost:5000.
Documentation at http://localhost:5000/swagger/index.html (or Redoc equivalent).

Database Migrations:

How to apply database migrations using : dotnet ef database update /// add-migration init , update-database

Running Tests:

Commands to run both unit and integration tests:
dotnet test

Visual Studio - Test - Run All Test

----------------------------------------------------

  ***Development Plan***

1. Project Setup
dotnet new webapi -n ProjectManagementApp
Add Required Packages:
Accessible at project root - Dependecies

2. Define the Database Model

Entities
Migrations

3. API Layer

Endpoints:

    Projects Controller:
        POST /api/Project: Create a new project.
        GET /api/Project: Retrieve all projects.
        DELETE /api/Project/{id}: Delete a project by ID.

    Tasks Controller:
        POST /api/Task: Create a task under a specific project.
        GET /api/Task: Retrieve all tasks for a project.
        PUT /api/Task/{id}: Update the status of a task.
        DELETE /api/Task/{id}: Delete a task by ID.

-Services Layer:
Use Dependency Injection to provide the necessary services for handling business logic (ProjectService and TaskService).

-Validations
Use FluentValidation to validate input data for the creation of Projects and Tasks.

-JWT Authentication:
Implement JWT-based authentication
Microsoft.AspNetCore.Authentication.JwtBearer. Users must authenticate to access protected routes.

4. Testing

Unit Testing:
Write unit tests for the service layer using xUni

----------------------------------------------------------
