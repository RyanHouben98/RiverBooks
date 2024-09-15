using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

public record BookDto(
    Guid Id,
    string Name,
    string Author
);

internal interface IBookService 
{
    IEnumerable<BookDto> ListBooks();
}

internal class BookService : IBookService
{
    public IEnumerable<BookDto> ListBooks()
    {
        return [
            new BookDto(Guid.NewGuid(), "Book 1", "John Doe"),
            new BookDto(Guid.NewGuid(), "Book 2", "Jan Jansen")
        ];
    }
}

public static class BookEndpoints
{
    public static void MapBookEndpoints(this WebApplication app) 
    {
        app.MapGet("/books", (IBookService bookservice) => {
            return bookservice.ListBooks();
        });
    }
}

public static class BookServiceExtension
{
    public static IServiceCollection AddBookServices(this IServiceCollection services) 
    {
        services.AddSingleton<IBookService, BookService>();

        return services;
    }
}
