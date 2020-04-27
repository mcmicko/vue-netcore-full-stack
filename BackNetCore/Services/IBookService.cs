using System.Collections.Generic;
using BackNetCore.Models;

namespace BackNetCore.Services
{
  public interface IBookService
  {
    public List<Book> GetAllBooks();
    public BookService GetBook(int bookId);
    public void AddBook(Book book);
    public void DeleteBook(int bookId);
  }
}