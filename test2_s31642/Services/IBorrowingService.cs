namespace test2_s31642.Services;
using test2_s31642.DTOs;

public interface IBorrowingService
{
    Task<List<MemberResponseDto>> GetMembersAsync(string? email);
    Task ReturnBorrowingAsync(int id, BorrowingReturnDto request);
}