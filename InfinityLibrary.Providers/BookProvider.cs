using InfinityLibrary.Core.Providers;
using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Providers.TypeConvertors;
using InfinityLibrary.Shared.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfinityLibrary.Providers
{
    public class BookProvider : IBookProvider
    {
        private readonly IBookRepository _bookRepository;

        public BookProvider(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public IEnumerable<BookModel> GetAll()
        {
            return _bookRepository.GetAll().Select(BookModelConvertor.ToModel);
        }

        public IEnumerable<BookModel> GetAllRentable()
        {
            return _bookRepository.GetAllRentable().Select(BookModelConvertor.ToModel);
        }

        public BookModel GetById(long id)
        {
            return _bookRepository.GetById(id).ToModel();
        }

        public async Task Add(BookModel bookModel)
        {
            await _bookRepository.Add(bookModel.ToBook());
        }

        public async Task Update(BookModel bookModel)
        {
            await _bookRepository.Update(bookModel.ToBook());
        }

        public async Task DeleteById(long id)
        {
            await _bookRepository.DeleteById(id);
        }
    }
}