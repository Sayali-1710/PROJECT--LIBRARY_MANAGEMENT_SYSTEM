using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Models;
using PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Services;
using Microsoft.AspNetCore.Authorization;

namespace PROJECT__LIBRARY_MANAGEMENT_SYSTEM.Controllers
{
   [ Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()=> Ok(await _bookService.GetAllAsync());

        [HttpGet("{id}")]

        public async Task<IActionResult> Get (int id ) => Ok(await _bookService.GetByIdAsync(id));

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Book book)
        {
            await _bookService.AddAsync(book);
            return CreatedAtAction(nameof(Get), new { id = book.BookId }, book);
        }

        [Authorize(Roles = "Admin,Librarian")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update (int id, [FromBody] Book book)
        {
            if (id  != book.BookId) 
                return BadRequest();
            await _bookService.UpdateAsync(book);
            return NoContent();
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _bookService.DeleteAsync(id);
            return NoContent();
        }






    }
}
