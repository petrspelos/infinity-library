using InfinityLibrary.Core.Providers;
using InfinityLibrary.Shared.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InfinityLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookProvider _bookProvider;

        public BooksController(IBookProvider bookProvider)
        {
            _bookProvider = bookProvider;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<BookModel> GetBook()
        {
            return _bookProvider.GetAll();
        }

        // GET: api/Books/Rentable
        [HttpGet("Rentable")]
        public IEnumerable<BookModel> GetRentableBooks()
        {
            return _bookProvider.GetAllRentable();
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public IActionResult GetBook([FromRoute] long id)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            var book = _bookProvider.GetById(id);

            if (book == null) { return NotFound(); }

            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> PostBook([FromForm] BookModel book)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            try
            {
                await _bookProvider.Add(book);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            
            return Redirect($"../bookdetail/{book.Id}"); // TODO: Handle with Blazor instead
        }

        // POST: api/Books/Update/5
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> UpdateBookById([FromRoute] long id, [FromForm] BookModel book)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState); }

            book.Id = id;

            try
            {
                await _bookProvider.Update(book);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }

            return Redirect($"../../../bookdetail/{book.Id}"); // TODO: Handle with Blazor instead
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await _bookProvider.DeleteById(id);
            }
            catch (InvalidOperationException e)
            {
                return BadRequest(e.Message);
            }
            
            return Ok();
        }
    }
}