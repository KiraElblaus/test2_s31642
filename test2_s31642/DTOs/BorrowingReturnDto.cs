using System.ComponentModel.DataAnnotations;
namespace test2_s31642.DTOs;


public class BorrowingReturnDto
{
    [Required]
    public DateTime? ReturnDate { get; set; } = null!;
}