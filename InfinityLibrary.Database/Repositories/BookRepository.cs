using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityLibrary.Core.Entities;
using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Database.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InfinityLibrary.Database.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly InfinityDbContext _context;

        public BookRepository(InfinityDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Book;
        }

        public IEnumerable<Book> GetAllRentable()
        {
            var books = _context.Book.ToList();
            var reservations = _context.Reservation.ToList();
            return books.Where(b => b.Copies > reservations.Count(r => r.BookId == b.Id));
        }

        public Book GetById(long id)
        {
            return _context.Book.FirstOrDefault(b => b.Id == id);
        }

        public async Task Add(Book book)
        {
            _context.Book.Add(book);
            await SaveContextChangesOrThrow();
        }

        public async Task Update(Book book)
        {
            var rentedCopiesCount = _context.Reservation.Count(r => r.BookId == book.Id);

            if (book.Copies < rentedCopiesCount)
            {
                throw new InvalidOperationException($"The book copies amount cannot be changed to {book.Copies}, because {rentedCopiesCount} copies are currently rented.");
            }

            _context.Entry(book).State = EntityState.Modified;
            await SaveContextChangesOrThrow();
        }

        public async Task DeleteById(long id)
        {
            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                throw new InvalidOperationException("The book you are trying to delete could not be found.");
            }

            if (_context.Reservation.Any(r => r.BookId == id))
            {
                throw new InvalidOperationException("The book you are trying to delete has pending reservations.");
            }

            _context.Book.Remove(book);
            await SaveContextChangesOrThrow();
        }

        private async Task SaveContextChangesOrThrow()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Saving changes to the database failed. Please try again in a little bit.");
            }
        }
    }
}