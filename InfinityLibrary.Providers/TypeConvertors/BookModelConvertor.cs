using InfinityLibrary.Core.Entities;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Providers.TypeConvertors
{
    internal static class BookModelConvertor
    {
        internal static Book ToBook(this BookModel bookModel)
        {
            if (bookModel is null) { return null; }

            return new Book
            {
                Id = bookModel.Id,
                Title = bookModel.Title,
                Genre = bookModel.Genre,
                Author = bookModel.Author,
                PublicationYear = bookModel.PublicationYear,
                Copies = bookModel.Copies,
                ThumbnailUrl = bookModel.ThumbnailUrl
            };
        }

        internal static BookModel ToModel(this Book book)
        {
            if (book is null) { return null; }

            return new BookModel
            {
                Id = book.Id,
                Title = book.Title,
                Genre = book.Genre,
                Author = book.Author,
                PublicationYear = book.PublicationYear,
                Copies = book.Copies,
                ThumbnailUrl = book.ThumbnailUrl
            };
        }
    }
}