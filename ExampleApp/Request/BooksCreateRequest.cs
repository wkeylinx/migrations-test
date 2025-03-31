namespace ExampleApp.Request;

public class BooksCreateRequest
{
	public string Title { get; set; }
	public int Review { get; set; }
	public string Author { get; set; }
	public DateTime PublishedDate { get; set; }
}