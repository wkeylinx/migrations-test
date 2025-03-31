# ExampleApp

**ExampleApp** is a .NET application utilizing Entity Framework Core with SQLite as the database provider. It demonstrates runtime creation of the DbContext, database-first setup with SQLite, and code-first migrations using EF Core 9.

## 📦 Project Structure

### `ExampleApp`
The main application project.

- **`app.db`**  
  A file-based SQLite database used for local data persistence.

- **NuGet Package References**:
  - `Microsoft.EntityFrameworkCore.Design`  
    Provides design-time tools for Entity Framework Core. Required for creating and managing migrations.
  - `Microsoft.EntityFrameworkCore.Sqlite`  
    SQLite provider for EF Core. Enables using SQLite as the underlying relational database.

### `ExampleLib.Data`
A class library that contains all database-related logic:

- Entity classes (models)
- `DbContext` definition
- EF Core configuration and setup

- **NuGet Package References**:
  - `Microsoft.EntityFrameworkCore` (`v9.0.3`)  
    Core functionality for EF Core (modeling, querying, change tracking, etc).
  - `Microsoft.EntityFrameworkCore.Relational` (`v9.0.3`)  
    Adds support for relational database features like table mapping and query translation.
  - `Microsoft.EntityFrameworkCore.Tools` (`v9.0.3`)  
    Tools for developer operations like migrations and scaffolding (used via CLI or Visual Studio).

## ✅ Getting Started

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download)
- (Optional) [DB Browser for SQLite](https://sqlitebrowser.org/) or any SQLite tool to inspect `app.db`


## ⚖️ Using Migrations in Package Manager Console

In Visual Studio, you can manage EF Core migrations using the **Package Manager Console**.

### Add a Migration
Creates a new migration based on changes in your model.
```powershell
Add-Migration MigrationName -Project ExampleLib.Data -StartupProject ExampleApp
```
- Replace `MigrationName` with a descriptive name.
- `-Project` is the class library containing `DbContext`.
- `-StartupProject` is the application that runs (usually the UI or API).

### Remove a Migration
Removes the last migration (useful if it hasn’t been applied to the database).
```powershell
Remove-Migration -Project ExampleLib.Data -StartupProject ExampleApp
```

### Update the Database
Applies pending migrations to the database.
```powershell
Update-Database -Project ExampleLib.Data -StartupProject ExampleApp
```
### Create Database Scripts Based On Migrations
Applies pending migrations to the database.
```powershell
Script-Migration -From Migration1 -To Migration2 -Project ExampleLib.Data -StartupProject ExampleApp
```

Make sure the correct Default Project is selected in the console dropdown when executing these commands.

---

## 📜 Notes

- EF Core Version: `9.0.3`
- SQLite database file: `app.db`
- The `DbContext` and entities are located in the `ExampleLib.Data` library for modular design.

---

Feel free to contribute or fork this project for your own learning or development needs!
