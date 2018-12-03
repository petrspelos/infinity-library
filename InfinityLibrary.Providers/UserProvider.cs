using InfinityLibrary.Core.Providers;
using InfinityLibrary.Core.Repositories;

namespace InfinityLibrary.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}