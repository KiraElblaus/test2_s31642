namespace test2_s31642.DTOs;

public class MemberResponseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;
    public List<BorrowingResponseDto> Borrowings { get; set; } = new();
}

public class BorrowingResponseDto
{
    public int BorrowingId { get; set; }
    public BookResponseDto Book { get; set; } = new BookResponseDto();
    public DateTime BorrowingDate { get; set; }
    public DateTime? ReturnDate { get; set; }
    public string Status { get; set; } = string.Empty;
}

public class BookResponseDto
{
    public int BookId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string ISBN { get; set; } = string.Empty;
    public int PublishedYear { get; set; }
    public AuthorResponseDto Author { get; set; } = new AuthorResponseDto();
}

public class AuthorResponseDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
}