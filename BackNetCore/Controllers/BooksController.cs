using System;
using BackNetCore.Controllers.RequestModel;
using BackNetCore.Models;
using BackNetCore.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackNetCore.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly ILogger<BooksController> _logger;
    private readonly IBookService _bookService;
    public BooksController(ILogger<BooksController> logger, IBookService bookService)
    {
      _logger = logger;
      _bookService = bookService;
    }

    [HttpGet]
    public ActionResult GetBooks()
    {
      var books = _bookService.GetAllBooks();
      return Ok(books);
    }

    [HttpPost]
    public ActionResult CreateBook([FromBody] NewBookRequest bookRequest)
    {
      if (!ModelState.IsValid)
      {
        return BadRequest("Model state note valid");
      }

      var now = DateTime.UtcNow;
      var book = new Book
      {
        CreatedOn = now,
        UpdatedOn = now,
        Title = bookRequest.Title,
        Author = bookRequest.Author
      };
      _bookService.AddBook(book);

      return Ok($"Book created: {book.Title}");
    }

    [HttpGet("{bookId}")]
    public ActionResult GetBook(int bookId)
    {
      var book = _bookService.GetBook(bookId);
      return Ok(book);
    }

    [HttpDelete("{bookId}")]
    public ActionResult deleteBook(int bookId)
    {
      _bookService.DeleteBook(bookId);
      return Ok("book deleted");
    }
  }
}