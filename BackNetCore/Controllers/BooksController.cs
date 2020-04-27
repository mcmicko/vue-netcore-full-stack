using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BackNetCore.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class BooksController : ControllerBase
  {
    private readonly ILogger<BooksController> _logger;
    public BooksController(ILogger<BooksController> logger)
    {
      _logger = logger;
    }

    [HttpGet]
    public ActionResult GetBooks()
    {
      return Ok("book!");
    }
  }
}