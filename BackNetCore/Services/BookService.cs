using System;
using System.Collections.Generic;
using System.Linq;
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
      _db.Add(book);
      _db.SaveChanges();
    }

    public void DeleteBook(int bookId)
    {
      var bookToDelete = _db.Books.Find(bookId);
      if (bookToDelete != null)
      {
        _db.Remove(bookToDelete);
        _db.SaveChanges();
      }
      else
      {
        throw new InvalidOperationException("Can't delete book that doesnt exist");
      }
    }

    public List<Book> GetAllBooks()
    {
      return _db.Books.ToList();
    }

    public Book GetBook(int bookId)
    {
      return _db.Books.Find(bookId);
    }
  }
}