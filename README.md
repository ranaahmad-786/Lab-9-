# Lab 9 - ASP.NET Core MVC with SQLite

This project demonstrates the main ASP.NET Core MVC flow:

- **Model:** `Models/Product.cs`
- **Database:** `Data/AppDbContext.cs`
- **Controller:** `Controllers/ProductsController.cs`
- **Views:** `Views/Products/`
- **SQLite setup:** `setup.sql`

The application supports listing, creating, viewing, editing, and deleting products.

## Run

Open a terminal in this folder and run:

```powershell
dotnet run
```

Then open `http://localhost:5028` if that URL is shown in the terminal.

The application automatically creates `lab9.db` and inserts two example products on first run.

## SQLite setup script

`setup.sql` contains the same product table and sample data in SQL. It can be run with a SQLite tool such as the SQLite CLI:

```powershell
sqlite3 lab9.db < setup.sql
```

No SQL Server or SQL Server configuration is required.
