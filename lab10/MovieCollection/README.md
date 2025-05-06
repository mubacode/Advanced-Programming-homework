# MovieCollection

A simple ASP.NET Core MVC web application for managing a collection of movies.

## Project Overview
This project demonstrates how to build a web application using the Model-View-Controller (MVC) pattern in ASP.NET Core. The application allows users to manage a movie collection with full Create, Read, Update, and Delete (CRUD) functionality. It uses Entity Framework Core for database access and migrations, and includes initial data seeding.

## Task Description
The goal is to implement a web app for managing movies, following the official ASP.NET Core MVC tutorial. The app should:
- Use the MVC pattern
- Define a Movie model
- Use a strongly-typed DbContext
- Provide CRUD operations for movies
- Use routing for navigation
- Use Razor views (.cshtml)
- Support database migrations and seeding

## Key Concepts and Answers

### 1. What is the MVC pattern?
**MVC** stands for Model-View-Controller:
- **Model**: Represents the data and business logic (e.g., `Movie` class).
- **View**: UI templates that render HTML (e.g., `.cshtml` files in `Views/Movies/`).
- **Controller**: Handles user input, updates the model, and returns views (e.g., `MoviesController`).

### 2. How do you define a model for the application?
A model is a C# class that represents your data structure. Example:
```csharp
public class Movie
{
    public int Id { get; set; }
    [Required]
    [StringLength(100)]
    public string Title { get; set; }
    // ... other properties ...
}
```

### 3. What is a strongly-typed DbContext responsible for?
A `DbContext` manages database connections and operations for your models. Example:
```csharp
public class MovieContext : DbContext
{
    public DbSet<Movie> Movies { get; set; }
}
```
It allows querying and saving `Movie` objects to the database.

### 4. How do you generate CRUD for a defined model?
By creating a controller (e.g., `MoviesController`) with actions for Create, Read, Update, Delete, and corresponding views in `Views/Movies/`.

### 5. How does routing work? What makes up a resource name in a URL?
Routing maps URLs to controller actions. Example: `/Movies/Edit/1` means:
- `Movies` = Controller
- `Edit` = Action
- `1` = Resource ID
Defined in `Program.cs`:
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```

### 6. Where is the default routing rule defined and what are its default values?
In `Program.cs`:
```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
```
Defaults: controller = `Home`, action = `Index`, `id` is optional.

### 7. What is a view and why does it have a .cshtml extension?
A view is a Razor template that generates HTML for the UI. `.cshtml` means it combines C# and HTML.

### 8. What does the View() method do?
The `View()` method in a controller returns a view to the user, optionally passing a model for rendering.
```csharp
public IActionResult Index()
{
    return View(); // Renders Views/Movies/Index.cshtml
}
```

### 9. What is the migration mechanism responsible for?
Migrations manage changes to the database schema. You create migrations when your model changes, and apply them to update the database.
```sh
dotnet ef migrations add InitialCreate
dotnet ef database update
```

### 10. How do you seed (initialize) the database with data?
By adding initial data in a static method called during app startup. Example:
```csharp
public static void Initialize(IServiceProvider serviceProvider)
{
    using (var context = new MovieContext(...))
    {
        if (!context.Movies.Any())
        {
            context.Movies.AddRange(
                new Movie { Title = "The Shawshank Redemption", ... },
                // more movies
            );
            context.SaveChanges();
        }
    }
}
```
And in `Program.cs`:
```csharp
SeedData.Initialize(services);
``` 