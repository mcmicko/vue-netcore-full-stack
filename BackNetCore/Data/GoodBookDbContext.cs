using BackNetCore.Models;
using Microsoft.EntityFrameworkCore;

namespace BackNetCore.Data
{
  public class GoodBookDbContext : DbContext
  {
    public GoodBookDbContext(DbContextOptions<GoodBookDbContext> options) : base(options) { }

    public virtual DbSet<Book> Books { get; set; }
    public virtual DbSet<BookReview> BookReviews { get; set; }
  }
}