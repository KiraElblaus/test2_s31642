namespace test2_s31642.Entities;
using System.ComponentModel.DataAnnotations;

public class Review
{
    public int MemberId { get; set; }
    public Member Member { get; set; } = null!;
    public int BookId { get; set; }
    public Book Book { get; set; } = null!;
    public int Rating { get; set; }
    [MaxLength(500)]
    public string Comment { get; set; } = string.Empty;
    public DateTime ReviewDate { get; set; }
}