using System;
using InfinityLibrary.Entities;
using InfinityLibrary.Server.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityLibrary.Shared.SharedModels;

namespace InfinityLibrary.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly InfinityDbContext _context;

        public ReservationsController(InfinityDbContext context)
        {
            _context = context;
        }

        // GET: api/Reservations
        [HttpGet]
        public IEnumerable<Reservation> GetReservation()
        {
            return _context.Reservation;
        }

        // GET: api/Reservations/Models
        [HttpGet("Models")]
        public IEnumerable<ReservedBookModel> GetReservationModels()
        {
            return _context.Reservation.Select(ReservationToReservedBook);
        }

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReservation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation = await _context.Reservation.FindAsync(id);

            if (reservation == null)
            {
                return NotFound();
            }

            return Ok(reservation);
        }

        // GET: api/Reservations/ForUser/5
        [HttpGet("ForUser/{id}")]
        public IEnumerable<ReservedBookModel> GetReservationsForUser([FromRoute] long id)
        {
            var reservedBooks = _context.Reservation
                .Where(r => r.UserId == id)
                .AsEnumerable()
                .Select(ReservationToReservedBook)
                .ToList();

            return !reservedBooks.Any() ? new List<ReservedBookModel>() : reservedBooks;
        }

        // PUT: api/Reservations/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservation([FromRoute] long id, [FromBody] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reservation.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservation).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservationExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Reservations
        [HttpPost]
        public async Task<IActionResult> PostReservation([FromForm] Reservation reservation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            reservation.Date = DateTime.Today;

            var renter = _context.User.Find(reservation.UserId);
            var book = _context.Book.Find(reservation.BookId);

            if (renter is null || book is null || renter.MembershipValidTill < DateTime.Now)
            {
                return BadRequest();
            }

            var rentedCopiesCount = _context.Reservation.Count(r => r.BookId == book.Id);

            if (book.Copies <= rentedCopiesCount)
            {
                return BadRequest();
            }

            _context.Reservation.Add(reservation);
            await _context.SaveChangesAsync();

            return Redirect($"../userdetail/{reservation.UserId}");
        }

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var reservation = await _context.Reservation.FindAsync(id);
            if (reservation == null)
            {
                return NotFound();
            }

            var userId = reservation.UserId;

            _context.Reservation.Remove(reservation);
            await _context.SaveChangesAsync();

            return Ok();
        }

        private bool ReservationExists(long id)
        {
            return _context.Reservation.Any(e => e.Id == id);
        }

        private ReservedBookModel ReservationToReservedBook(Reservation reservation)
        {
            var book = _context.Book.Find(reservation.BookId);

            return new ReservedBookModel
            {
                Id = book.Id,
                ThumbnailUrl = book.ThumbnailUrl,
                PublicationYear = book.PublicationYear,
                Copies = book.Copies,
                Author = book.Author,
                Title = book.Title,
                Genre = book.Genre,
                ReservationId = reservation.Id,
                ReservationDate = reservation.Date
            };
        }
    }
}