namespace test2_s31642.Entities;
using System.ComponentModel.DataAnnotations;

public class Author
{
    public int AuthorId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    [MaxLength(50)]
    public string Country { get; set; } = string.Empty;
    public int BirthYear { get; set; }
    
    public ICollection<Book> Books { get; set; } = new List<Book>();
    
}