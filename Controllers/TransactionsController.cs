using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.DTOs;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {

        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [Authorize(Roles = "Member,Librarian,Admin")]
        [HttpPost("borrow")]
        public async Task<IActionResult> Borrow([FromBody] BorrowRequest req)
        {
            try
            {
                await _transactionService.BorrowAsync(req);
                return Ok(new { message = "Book borrowed" });
            }
            catch (Exception ex)
            {
                return BadRequest(new {error = ex.Message});
            }
        }


        [Authorize(Roles ="Member,Librarian,Admin")]
        [HttpPost("return")]
        public async Task<IActionResult> Return([FromBody] ReturnRequest req)
        {
            try
            {
                await _transactionService.ReturnAsync(req);
                return Ok(new { message = "Book Retured" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message });
            }
        }













    }
}
