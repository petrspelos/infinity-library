using System.Collections.Generic;
using System.Threading.Tasks;
using InfinityLibrary.Core.Entities;

namespace InfinityLibrary.Core.Repositories
{
    public interface IUserRepository
    {
        IEnumerable<User> GetAll();
        IEnumerable<User> GetAllWithMembership();
        Task<User> GetById(long id);
        Task Update(User user);
        Task Add(User user);
        Task DeleteById(long id);
    }
}