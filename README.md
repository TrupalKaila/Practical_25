# Practical-25 

This repository contains a .NET Core Web API solution that implements CRUD-style employee operations using the Mediator pattern (MediatR) and FluentValidation.

## Solution structure

- **EmployeeAPI**: ASP.NET Core Web API project (controllers, DI setup, Swagger).
- **EmployeeDAL**: Data access layer (SQL access), MediatR handlers, DTOs, validators, and models.

## Features implemented

- **Create** employee (Name, Salary, DepartmentId, EmailId)
- **Update** employee by Id (Id, Name, Salary, DepartmentId, EmailId)
- **Soft delete** (Deactivate) employee by Id
- **Get** employee(s): list all or get by Id
- **Mediator pattern** using MediatR command/query handlers
- **FluentValidation** for create/update DTOs

## Database

The data access layer uses SQL Server (LocalDB by default). Connection string is configured in `EmployeeDAL/Data/DbService.cs`.

### Table schema

Run the following SQL to create the `Employee` table:

```sql
CREATE TABLE Employee (
    EmployeeId INT IDENTITY(1,1) PRIMARY KEY,
    EmployeeName NVARCHAR(100) NOT NULL,
    EmployeeSalary DECIMAL(18,2) NOT NULL,
    DepartmentId INT NOT NULL,
    EmployeeEmail NVARCHAR(256) NOT NULL,
    EmployeeJoiningDate DATETIME2 NOT NULL,
    EmployeeStatus NVARCHAR(50) NOT NULL
);
```

> Notes:
> - `EmployeeId` is an identity column.
> - `EmployeeStatus` is used for soft delete (`Active`/`InActive`).

### DepartmentId mapping

The current implementation expects a numeric `DepartmentId` (int). You can map department values as follows:

| DepartmentId | Department |
| --- | --- |
| 1 | IT |
| 2 | Admin |
| 3 | HR |
| 4 | Sales |
| 5 | On-site |

## API endpoints

Base route: `/api/employee`

### Create employee

`POST /api/employee`

Request body:

```json
{
  "employeeName": "John Doe",
  "employeeSalary": 60000,
  "departmentId": 1,
  "employeeEmail": "john.doe@example.com",
  "employeeJoiningDate": "2024-01-01T00:00:00"
}
```

### Update employee

`PUT /api/employee`

Request body:

```json
{
  "employeeId": 1,
  "employeeName": "John Doe",
  "employeeSalary": 65000,
  "departmentId": 1,
  "employeeEmail": "john.doe@example.com"
}
```

### Soft delete (deactivate) employee

`DELETE /api/employee/{id}`

### Get all employees

`GET /api/employee`

### Get employee by id

`GET /api/employee/{id}`

## Validation

FluentValidation is registered in the API project and applied to the DTOs in the handlers:

- `AddEmployeeValidator`
- `UpdateEmployeeValidator`

## Running the project

1. Ensure SQL Server LocalDB is installed, or update the connection string in `EmployeeDAL/Data/DbService.cs`.
2. Create the `Employee` table using the SQL above.
3. Run the API:

```bash
dotnet run --project EmployeeAPI
```

Swagger will be available in Development at `/swagger`.
