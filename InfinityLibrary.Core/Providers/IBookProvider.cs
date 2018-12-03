using System.Collections.Generic;
using System.Threading.Tasks;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Core.Providers
{
    public interface IBookProvider
    {
        IEnumerable<BookModel> GetAll();
        IEnumerable<BookModel> GetAllRentable();
        BookModel GetById(long id);
        Task Add(BookModel bookModel);
        Task Update(BookModel bookModel);
        Task DeleteById(long id);
    }
}