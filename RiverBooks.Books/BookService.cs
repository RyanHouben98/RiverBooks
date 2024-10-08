
namespace RiverBooks.Books;

internal class BookService : IBookService
{
  private readonly IBookRepository _bookRepository;

  public BookService(IBookRepository bookRepository)
  {
    _bookRepository = bookRepository;
  }

  public async Task CreateBookAsync(BookDto newBook)
  {
    var book = new Book(Guid.NewGuid(), newBook.Title, newBook.Author, newBook.Price);

    await _bookRepository.AddAsync(book);
    await _bookRepository.SaveChangesAsync();
  }

  public async Task DeleteBookAsync(Guid id)
  {
    var book = await _bookRepository.GetByIdAsync(id);

    if (book is not null) 
    {
      await _bookRepository.DeleteAsync(book);
      await _bookRepository.SaveChangesAsync();
    }
  }

  public async Task<BookDto?> GetBookByIdAsync(Guid id)
  {
    var book = await _bookRepository.GetByIdAsync(id);

    if (book is null)
    {
      return null;
    } 

    return new BookDto(book!.Id, book.Title, book.Author, book.Price);
  }

  public async Task<List<BookDto>> ListBooksAsync()
  {
    var books = (await _bookRepository.ListBooksAsync())
      .Select(book => new BookDto(book.Id, book.Title, book.Author, book.Price))
      .ToList();

      return books;
  }

  public async Task UpdateBookPriceAsync(Guid id, decimal newPrice)
  {
    var book = await _bookRepository.GetByIdAsync(id);

    book!.UpdatePrice(newPrice);

    await _bookRepository.SaveChangesAsync();
  }
}
