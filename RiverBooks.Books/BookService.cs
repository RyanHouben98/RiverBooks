namespace RiverBooks.Books;

internal class BookService : IBookService
{
    public List<BookDto> ListBooks()
    {
        return [
            new BookDto(Guid.NewGuid(), "Book 1", "John Doe"),
            new BookDto(Guid.NewGuid(), "Book 2", "Jan Jansen")
        ];
    }
}
