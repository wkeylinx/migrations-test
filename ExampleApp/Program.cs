#region Imports
using ExampleApp.Request; 
using ExampleApp.Response; 
using ExampleLib.Data; 
using ExampleLib.Data.Entities; 
using Microsoft.AspNetCore.Mvc; 
using Microsoft.EntityFrameworkCore;
#endregion

// Create a new WebApplication builder
var builder = WebApplication.CreateBuilder(args);

#region Services
// Add support for API endpoint exploration 
builder.Services.AddEndpointsApiExplorer();

// Add support for generating Swagger documentation
builder.Services.AddSwaggerGen();

// Add the ApplicationDbContext to the service container
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
	// Configure the context to use SQLite with the specified database file
	options.UseSqlite("Data Source=app.db"); 
});

#endregion

// Builds the WebApplication
var app = builder.Build();

#region HTTP request pipelines
// Check if the application is in development environment
if (app.Environment.IsDevelopment())
{
	app.UseSwagger(); // Enable Swagger middleware
	app.UseSwaggerUI(); // Enable Swagger UI middleware
}

// Enable HTTPS redirection middleware
app.UseHttpsRedirection(); 

app.MapGet("/Books", async (ApplicationDbContext db) => // Map a GET endpoint for "/Books"
{
	// Select and project Book entities to BookResponse objects
	return await db.Books.Select(book => new BookResponse 
	{
		Review = book.Review, 
		Author = book.Author, 
		PublishedDate = book.PublishedDate,
		Title = book.Title, 
		Id = book.Id 
	}).OrderByDescending(x=> x.Id).ToListAsync(); // Convert the result to a list asynchronously
});

app.MapPost("/Books/Create", async ([FromBody] BooksCreateRequest request, ApplicationDbContext db) => // Map a POST endpoint for "/Books/Create"
{
	await db.AddAsync(new Book // Add a new Book entity to the context
	{
		Author = request.Author,
		PublishedDate = request.PublishedDate,
		Review = request.Review,
		Title = request.Title
	});
	await db.SaveChangesAsync(); // Save changes to the database asynchronously
	return Results.Ok(); // Return an Ok result
});

app.Run(); // Run the application


#endregion

