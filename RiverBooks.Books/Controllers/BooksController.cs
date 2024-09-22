using Microsoft.AspNetCore.Mvc;
using RiverBooks.Books.Requests;

namespace RiverBooks.Books.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
  private readonly IBookService _bookService = bookService;

  [HttpGet]
  public async Task<IActionResult> ListBooksAsync()
  {
    var response = await _bookService.ListBooksAsync();

    return Ok(response);
  }

  [HttpGet("{id:guid}")]
  public async Task<IActionResult> GetBookByIdAsync([FromRoute] Guid id)
  {
    var response = await _bookService.GetBookByIdAsync(id);

    if (response is null) 
    {
      return NotFound();
    }

    return Ok(response);
  }

  [HttpPost]
  public async Task<IActionResult> CreateBookAsync([FromBody] CreateBookRequest request)
  {
    var bookDto = new BookDto(null, request.Name, request.Author, request.Price);

    await _bookService.CreateBookAsync(bookDto);

    return Ok();
  }
}