using System.Collections.Generic;
using BackNetCore.Data;
using BackNetCore.Models;

namespace BackNetCore.Services
{
  public class BookService : IBookService
  {
    private readonly GoodBookDbContext _db;
    public BookService(GoodBookDbContext db)
    {
      _db = db;
    }
    public void AddBook(Book book)
    {
      throw new System.NotImplementedException();
    }

    public void DeleteBook(int bookId)
    {
      throw new System.NotImplementedException();
    }

    public List<Book> GetAllBooks()
    {
      throw new System.NotImplementedException();
    }

    public BookService GetBook(int bookId)
    {
      throw new System.NotImplementedException();
    }
  }
}