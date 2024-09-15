using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

public static class BookServiceExtension
{
    public static IServiceCollection AddBookServices(this IServiceCollection services) 
    {
        services.AddSingleton<IBookService, BookService>();

        return services;
    }
}
