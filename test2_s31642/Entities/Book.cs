namespace test2_s31642.Entities;
using System.ComponentModel.DataAnnotations;

public class Book
{
    public int BookId { get; set; }
    [MaxLength(200)]
    public string Title { get; set; } = string.Empty;
    [MaxLength(13)]
    public string ISBN { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;
    
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}