# ManagementPortal

REST API to web application management of inventory, products, customers and orders.

## About

- REST API development with .NET Core

- Using SQL with a PostgreSQL database

- Unit testing with xUnit

- End-to-end testing with Cypress

## Requeriments

- [Docker](https://www.docker.com/get-started) (Optional)
- [.NET Core](https://dotnet.microsoft.com/download/dotnet/6.0)
- [PostgreSQL](https://www.postgresql.org/)

## How to run

Create PostgreSQL database:

```bash
docker-compose up
```

Build the project:

```bash
dotnet build
```

Run migrations:

```bash
cd ManagementPortal.Data/
dotnet ef --startup-project ../ManagementPortal.Api database update
```

Run API project

```bash
cd SolarCoffee.Api/
dotnet run
```

Then go to <http://localhost:5001/api>
