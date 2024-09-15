using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RiverBooks.Books;

internal class BookConfiguration : IEntityTypeConfiguration<Book>
{
  internal static readonly Guid Book1Guid = new Guid("a4d6350f-0c5b-49e6-9c42-c1aa96396db9");
  internal static readonly Guid Book2Guid = new Guid("c1bbd273-1849-4f6e-91da-0ecc17eb3eac");
  internal static readonly Guid Book3Guid = new Guid("9aaa9ee0-ca80-4f86-8f17-7494b0d95056");

  public void Configure(EntityTypeBuilder<Book> builder)
  {
    builder.HasKey(book => book.Id);
    
    builder.Property(book => book.Title)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.Property(book => book.Author)
      .HasMaxLength(DataSchemaConstants.DEFAULT_NAME_LENGTH)
      .IsRequired();

    builder.HasData(GetSampleBookData());
  }

  private IEnumerable<Book> GetSampleBookData()
  {
    var johnDoe = "John Doe";

    yield return new Book(Book1Guid, "Book 1", johnDoe, 10.99m);
    yield return new Book(Book2Guid, "Book 2", johnDoe, 11.99m);
    yield return new Book(Book3Guid, "Book 3", johnDoe, 12.99m);
  }
}
