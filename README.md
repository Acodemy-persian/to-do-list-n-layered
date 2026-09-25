# ToDoList

A simple task management Web API built with **.NET 10** using a layered
architecture.

## Architecture

The solution is divided into four projects:

``` text
ToDoList
├── Domain
├── Application
├── DataAccess
└── Presentation
```

### Domain

Contains the core domain entities.

-   `WorkItem`

### Application

Contains application logic and contracts.

-   DTOs for task requests and responses
-   Service interfaces and implementations
-   AutoMapper profiles
-   Standard service response models
-   Error codes

Main components:

-   `ITaskService`
-   `TaskService`
-   `TaskMappingProfile`
-   `BaseServiceResponseModel`
-   `BaseServiceDataResponseModel<T>`
-   `ErrorCode`

### DataAccess

Handles database access using **Entity Framework Core**.

-   `AppDbContext`
-   `ITaskRepository`
-   `TaskRepository`
-   SQL Server integration

The main entity set is:

``` csharp
DbSet<WorkItem> WorkItems
```

### Presentation

The ASP.NET Core Web API layer.

-   Controllers
-   Dependency injection
-   Swagger UI
-   Service-result filter
-   Application and DataAccess registration

Main controller:

``` text
/api/Task
```

## API Operations

The task API provides the following operations:

  Method   Endpoint           Description
  -------- ------------------ ------------------
  POST     `/api/Task`        Create a task
  GET      `/api/Task`        Get all tasks
  GET      `/api/Task/{id}`   Get a task by ID
  PUT      `/api/Task`        Update a task
  DELETE   `/api/Task/{id}`   Remove a task

## Technologies

-   .NET 10
-   ASP.NET Core Web API
-   Entity Framework Core
-   SQL Server
-   AutoMapper
-   Swagger / OpenAPI
-   C#

## Database

Entity Framework Core migrations are used to create and update the
database schema.

From the solution root:

``` bash
dotnet ef migrations add <MigrationName> \
  --project DataAccess \
  --startup-project Presentation
```

Apply migrations:

``` bash
dotnet ef database update \
  --project DataAccess \
  --startup-project Presentation
```

## Running the API

From the `Presentation` project:

``` bash
dotnet run
```

The actual HTTP/HTTPS address is shown in the console when the
application starts.

## Swagger UI

When the application is running in the Development environment, Swagger
UI is available at:

``` text
/swagger
```

For example:

``` text
http://localhost:<port>/swagger
```

## Response Handling

Application services return standard response models.

Successful operations use:

``` text
BaseServiceResponseModel
BaseServiceDataResponseModel<T>
```

Errors are represented by `ErrorCode`, including:

-   `None`
-   `GeneralError`
-   `NotFound`
-   `Duplicate`

`HandleServiceResultAttribute` maps service errors to HTTP status codes.

## Project Status

This is a learning/development project demonstrating a layered ASP.NET
Core Web API with Entity Framework Core, repository and service
patterns, DTOs, AutoMapper, and standardized service responses.
