namespace test2_s31642.Data;
using test2_s31642.Entities;
using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Book> Books { get; set; } = null!;
    public DbSet<Borrowing> Borrowings { get; set; } = null!;
    public DbSet<Member> Members { get; set; } = null!;
    public DbSet<Review> Reviews { get; set; } = null!;


    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        
        modelBuilder.Entity<Review>()
            .HasKey(r => new { r.BookId, r.MemberId });
        modelBuilder.Entity<Borrowing>()
            .HasKey(b => new { b.BookId, b.MemberId });
    }
}