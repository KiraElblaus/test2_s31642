namespace test2_s31642.Entities;
using System.ComponentModel.DataAnnotations;

public class Borrowing
{
    public int BorrowingId { get; set; }
    public DateTime BorrowingDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    [MaxLength(50)]
    public string Status { get; set; } = string.Empty;
    public int MemberId { get; set; }
    public Member Member { get; set; } = null!;
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    
    
}