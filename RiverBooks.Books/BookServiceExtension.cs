using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RiverBooks.Books;

public static class BookServiceExtension
{
  public static IServiceCollection AddBookServices(
    this IServiceCollection services,
    ConfigurationManager configurationManager) 
  {
    string? connectionString = configurationManager.GetConnectionString("BooksConnectionString");

    services.AddDbContext<BookDbContext>(options =>
      options.UseSqlite(connectionString));

    services.AddScoped<IBookService, BookService>();
    services.AddScoped<IBookRepository, BookRepository>();

    return services;
  }
}
