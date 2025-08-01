# Product Showcase Dashboard

This is a .NET Core web application for showcasing products.

## Project Structure

- `ProductShowcase.Core`: Contains core models and business logic.
- `ProductShowcase.WebApp`: The main ASP.NET Core web application, including controllers, views, and data context.

## Getting Started

### Prerequisites

- .NET SDK (version compatible with the project)

### Setup

1. Clone the repository:
   ```bash
   git clone <https://github.com/Eko-347m4n/Product-Showcase-Dashboard.git>
   cd "Product Showcase Dashboard"
   ```
2. Restore NuGet packages:
   ```bash
   dotnet restore ProductShowcase.sln
   ```
3. Apply database migrations:
   ```bash
   dotnet ef database update --project ProductShowcase.WebApp
   ```

### Running the Application

To run the application, navigate to the `ProductShowcase.WebApp` directory and execute:

```bash
cd ProductShowcase/ProductShowcase.WebApp
dotnet run
```

The application should then be accessible in your web browser, usually at `https://localhost:5001` or `http://localhost:5000`.
