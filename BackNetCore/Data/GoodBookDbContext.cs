using BackNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BackNetCore.Data
{
  public class GoodBookDbContext : DbContext
  {
    public GoodBookDbContext() { }
    public GoodBookDbContext(DbContextOptions options) : base() { }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookReview> BookReviews { get; set; }
  }
}