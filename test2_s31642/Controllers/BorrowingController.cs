using test2_s31642.DTOs;

namespace test2_s31642.Controllers;
using Microsoft.AspNetCore.Mvc;
using test2_s31642.Services;


[ApiController]
[Route("api/orders")]
public class BorrowingController : ControllerBase
{
    private readonly IBorrowingService _borrowingService;
    
    public BorrowingController(IBorrowingService borrowingService)
    {
        _borrowingService = borrowingService;
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<List<MemberResponseDto>>> GetMembersAsync(string? email)
    {
        return Ok(await _borrowingService.GetMembersAsync(email));
    }
    
    [HttpPut("borrowings/{id}/return")]
    public async Task<ActionResult> ReturnBorrowingAsync(int id, BorrowingReturnDto request)
    {
        await _borrowingService.ReturnBorrowingAsync(id, request);
        return NoContent();
    }
}