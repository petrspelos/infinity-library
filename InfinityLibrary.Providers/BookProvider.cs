using InfinityLibrary.Core.Providers;
using InfinityLibrary.Core.Repositories;

namespace InfinityLibrary.Providers
{
    public class BookProvider : IBookProvider
    {
        private readonly IBookRepository _bookRepository;

        public BookProvider(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
    }
}