using ExampleLib.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ExampleLib.Data
{

	public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> optionsBuilder)
		: DbContext(optionsBuilder)
	{
		public DbSet<Book> Books { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// maps the primary key for the Book entity
			modelBuilder.Entity<Book>().HasKey(b => b.Id);

			// seeds the database with initial data for the Book entity
			modelBuilder.Entity<Book>().HasData(
			new Book { Id = 1, Title = "Book One", Review = 5, Author = "Author One", PublishedDate = new DateTime(2020, 1, 1) },
			new Book { Id = 2, Title = "Book Two", Review = 4, Author = "Author Two", PublishedDate = new DateTime(2021, 2, 2) },
			new Book { Id = 3, Title = "Book Three", Review = 3, Author = "Author Three", PublishedDate = new DateTime(2022, 3, 3) },
			new Book { Id = 4, Title = "1984", Review = 5, Author = "George Orwell", PublishedDate = new DateTime(1949, 6, 8) },
			new Book { Id = 5, Title = "To Kill a Mockingbird", Review = 5, Author = "Harper Lee", PublishedDate = new DateTime(1960, 7, 11) },
			new Book { Id = 6, Title = "The Great Gatsby", Review = 4, Author = "F. Scott Fitzgerald", PublishedDate = new DateTime(1925, 4, 10) },
			new Book { Id = 7, Title = "Moby Dick", Review = 4, Author = "Herman Melville", PublishedDate = new DateTime(1851, 10, 18) },
			new Book { Id = 8, Title = "Pride and Prejudice", Review = 5, Author = "Jane Austen", PublishedDate = new DateTime(1813, 1, 28) },
			new Book { Id = 9, Title = "War and Peace", Review = 5, Author = "Leo Tolstoy", PublishedDate = new DateTime(1869, 1, 1) },
			new Book { Id = 10, Title = "The Catcher in the Rye", Review = 4, Author = "J.D. Salinger", PublishedDate = new DateTime(1951, 7, 16) },
			new Book { Id = 11, Title = "The Hobbit", Review = 5, Author = "J.R.R. Tolkien", PublishedDate = new DateTime(1937, 9, 21) },
			new Book { Id = 12, Title = "Fahrenheit 451", Review = 4, Author = "Ray Bradbury", PublishedDate = new DateTime(1953, 10, 19) },
			new Book { Id = 13, Title = "Jane Eyre", Review = 5, Author = "Charlotte Brontë", PublishedDate = new DateTime(1847, 10, 16) }
			);
			base.OnModelCreating(modelBuilder);
		}
	}
}
