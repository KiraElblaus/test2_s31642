namespace test2_s31642.Services;
using test2_s31642.DTOs;
using test2_s31642.Entities;
using test2_s31642.Data;
using Microsoft.EntityFrameworkCore;


public class BorrowingService : IBorrowingService
{
    private readonly AppDbContext _context;
    
    public BorrowingService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<List<MemberResponseDto>> GetMembersAsync(string? email)
    {
        var query = _context.Members
            .Include(m => m.Borrowings)
            .ThenInclude(b => b.Book)
            .ThenInclude(bk => bk.Author)
            .AsSplitQuery()
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(email))
        {
            query = query.Where(m => m.Email.Contains(email));
        }

        var members = await query.ToListAsync();

        return members.Select(m => new MemberResponseDto
        {
            FirstName = m.FirstName,
            LastName = m.LastName,
            Email = m.Email,
            Phone = m.Phone,
            Borrowings = m.Borrowings.Select(b => new BorrowingResponseDto
            {
                BorrowingId = b.BorrowingId,
                BorrowingDate = b.BorrowingDate,
                ReturnDate = b.ReturnDate!,
                Status = b.Status,
                Book = new BookResponseDto
                {
                    BookId = b.Book.BookId,
                    Title = b.Book.Title,
                    ISBN = b.Book.ISBN,
                    PublishedYear = b.Book.PublishedYear,
                    Author = new AuthorResponseDto
                    {
                        FirstName = b.Book.Author.FirstName,
                        LastName = b.Book.Author.LastName
                    }
                }
            }).ToList()
        }).ToList();
    }

    public async Task ReturnBorrowingAsync(int id, BorrowingReturnDto request)
    {
        var borrowing = await _context.Borrowings.FirstOrDefaultAsync(b => b.BorrowingId == id);

        if (borrowing == null)
        {
            throw new KeyNotFoundException("Borrowing with the given ID does not exist.");
        }

        if (borrowing.Status == "Returned")
        {
            throw new InvalidOperationException("This borrowing has already been returned.");
        }

        if (request.ReturnDate < borrowing.BorrowingDate)
        {
            throw new ArgumentException("Return date cannot be earlier than the borrow date.");
        }

        using var transaction = await _context.Database.BeginTransactionAsync();

        try
        {
            borrowing.ReturnDate = request.ReturnDate;
            borrowing.Status = "Returned";

            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}