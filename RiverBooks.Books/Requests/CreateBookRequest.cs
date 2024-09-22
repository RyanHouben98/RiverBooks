namespace RiverBooks.Books.Requests;

public record CreateBookRequest(
    string Name,
    string Author,
    decimal Price
);
