# Entity-Framework-Core-Migrations-Example

This repository demonstrates how to use Entity Framework Core migrations to manage database schema changes in a .NET 8 Web API project with SQL Server.

## Getting Started

1. **Clone the repository:**
   ```bash
   git clone https://github.com/hsuazo1993/Entity-Framework-Core-Migrations-Example.git
   ```

2. **Open the solution:** Open the `EFCoreMigrationsExample.sln` file in Visual Studio.

3. **Install the required packages:**
   Make sure you have the following NuGet packages installed in your Web API project:

   * `Microsoft.EntityFrameworkCore`
   * `Microsoft.EntityFrameworkCore.SqlServer`
   * `Microsoft.EntityFrameworkCore.Design`

4. **Configure the database connection:**
   In your `appsettings.json` or `appsettings.Development.json` file, add a connection string to your SQL Server database:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=MyDatabase;Trusted_Connection=True;MultipleActiveResultSets=true"
     }
   }
   ```

   * Replace `(localdb)\\mssqllocaldb` with your SQL Server instance name.
   * Replace `MyDatabase` with your desired database name.

5. **Register the DbContext:**
   In your `Program.cs` file, register the `ApplicationDbContext` with the dependency injection container:

   ```C#
   builder.Services.AddDbContext<ApplicationDbContext>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
   ```

6. **Create the initial migration:**
   Open the Package Manager Console (Tools > NuGet Package Manager > Package Manager Console) and run the following command:

   ```powershell
   Add-Migration InitialCreate -Context ApplicationDbContext
   ```

   This will create a migrations folder in your project with a new migration file containing the code to create the initial database schema.

7. **Update the database:**
   In the Package Manager Console, run the following command to apply the migration to your database:

   ```powershell
   Update-Database -Context ApplicationDbContext
   ```

   This will create the database (if it doesn't exist) and apply the migration, creating the tables and relationships defined in your `DbContext` and entities.

## Entities and DbContext

The project includes the following entities:

*   `Product`: Represents a product with properties like `Name`, `Description`, `Price`, and `QuantityInStock`.
*   `Order`: Represents an order with `OrderDate`, `CustomerName`, and a list of `OrderItems`.
*   `OrderItem`: Represents an item in an order, linking to both the `Order` and the `Product`.

The `ApplicationDbContext` class manages these entities and their relationships.

## Running the Example

1.  **Build and run the Web API project.**
2.  **Use a tool like Postman or Swagger UI** to send requests to the API endpoints and interact with the data.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvement, please feel free to submit a pull request.
