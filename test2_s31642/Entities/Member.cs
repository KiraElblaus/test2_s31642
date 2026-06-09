namespace test2_s31642.Entities;
using System.ComponentModel.DataAnnotations;

public class Member
{
    public int MemberId { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string LastName { get; set; } = string.Empty;
    [MaxLength(100)]
    public string Email { get; set; } = string.Empty;
    [MaxLength(9)]
    public string Phone { get; set; } = string.Empty;
    
    public ICollection<Review> Reviews { get; set; } = new List<Review>();
    public ICollection<Borrowing> Borrowings { get; set; } = new List<Borrowing>();
}