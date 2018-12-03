using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InfinityLibrary.Core.Providers;
using InfinityLibrary.Core.Repositories;
using InfinityLibrary.Providers.TypeConvertors;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Providers
{
    public class UserProvider : IUserProvider
    {
        private readonly IUserRepository _userRepository;

        public UserProvider(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public IEnumerable<UserModel> GetAll()
        {
            return _userRepository.GetAll().Select(UserModelConvertor.ToModel);
        }

        public IEnumerable<UserModel> GetAllWithMembership()
        {
            return _userRepository.GetAllWithMembership().Select(UserModelConvertor.ToModel);
        }

        public async Task<UserModel> GetById(long id)
        {
            return (await _userRepository.GetById(id)).ToModel();
        }

        public async Task Update(UserModel userModel)
        {
            await _userRepository.Update(userModel.ToUser());
        }

        public async Task Add(UserModel userModel)
        {
            var user = userModel.ToUser();
            user.MembershipValidTill = DateTime.Today;
            await _userRepository.Add(user);
        }

        public async Task DeleteById(long id)
        {
            await _userRepository.DeleteById(id);
        }
    }
}