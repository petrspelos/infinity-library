using System.Collections.Generic;
using System.Threading.Tasks;
using InfinityLibrary.Core.Entities;
using InfinityLibrary.Shared.Models;

namespace InfinityLibrary.Core.Providers
{
    public interface IUserProvider
    {
        IEnumerable<UserModel> GetAll();
        IEnumerable<UserModel> GetAllWithMembership();
        Task<UserModel> GetById(long id);
        Task Update(UserModel userModel);
        Task Add(UserModel userModel);
        Task DeleteById(long id);
    }
}