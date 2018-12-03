using System.Collections.Generic;
using System.Threading.Tasks;
using InfinityLibrary.Core.Entities;

namespace InfinityLibrary.Core.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        IEnumerable<Book> GetAllRentable();
        Book GetById(long id);
        Task Add(Book book);
        Task Update(Book book);
        Task DeleteById(long id);
    }
}