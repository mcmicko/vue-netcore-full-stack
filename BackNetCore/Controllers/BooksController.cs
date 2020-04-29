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
  }
}