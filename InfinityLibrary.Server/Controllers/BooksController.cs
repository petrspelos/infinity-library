using InfinityLibrary.Entities;
using InfinityLibrary.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using System.Web;
using InfinityLibrary.Shared;

namespace InfinityLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly InfinityDbContext _context;

        public BooksController(InfinityDbContext context)
        {
            _context = context;
        }

        // GET: api/Books
        [HttpGet]
        public IEnumerable<Book> GetBook()
        {
            return _context.Book;
        }

        // GET: api/Books/Rentable
        [HttpGet("Rentable")]
        public IEnumerable<Book> GetBooksRentable()
        {
            var allBooks = _context.Book.ToList();
            var allReservations = _context.Reservation.ToList();

            return allBooks.Where(b => b.Copies > allReservations.Count(r => r.BookId == b.Id));
        }

        // GET: api/Books/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Book.FindAsync(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // POST: api/Books
        [HttpPost]
        public async Task<IActionResult> PostBook([FromForm] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Book.Add(book);
            await _context.SaveChangesAsync();

            return Redirect($"../bookdetail/{book.Id}");
        }

        // POST: api/Books/Update/5
        [HttpPost("Update/{id}")]
        public async Task<IActionResult> PutBook([FromRoute] long id, [FromForm] Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            book.Id = id;
            
            var rentedCopiesCount = _context.Reservation.Count(r => r.BookId == id);

            if (book.Copies < rentedCopiesCount)
            {
                return Redirect($"../../../error/{ErrorMessage.InvalidBookCountEdit.ToString()}");
            }

            _context.Entry(book).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Redirect($"../../../bookdetail/{book.Id}");
        }

        // DELETE: api/Books/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBook([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            if (_context.Reservation.Any(r => r.BookId == id))
            {
                return BadRequest("Book is reserved");
            }

            _context.Book.Remove(book);
            await _context.SaveChangesAsync();

            return Ok(book);
        }

        private bool BookExists(long id)
        {
            return _context.Book.Any(e => e.Id == id);
        }
    }
}