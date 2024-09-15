using Ardalis.GuardClauses;

namespace RiverBooks.Books;

internal class Book
{
    public Guid Id { get; private set; } = Guid.NewGuid();
    public string Name { get; private set; } = string.Empty;
    public string Author { get; private set; } = string.Empty;
    public decimal Price { get; private set; }

    internal Book(
        Guid id,
        string name,
        string author,
        decimal price
    )
    {
        Id = Guard.Against.Default(id);
        Name = Guard.Against.NullOrEmpty(name);
        Author = Guard.Against.NullOrEmpty(author);
        Price = Guard.Against.Negative(price);
    }

    internal void UpdatePrice(decimal newPrice) 
    {
        Price = Guard.Against.Negative(newPrice);
    }
}
