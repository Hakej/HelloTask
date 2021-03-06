using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Core.Domain;

namespace HelloTask.Core.Repositories
{
    public interface IUserRepository : IRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetByEmailAsync(string email);
        Task<IEnumerable<User>> GetAllAsync();
        Task AddAsync(User user);
        Task UpdateAsync(User user);
        Task DeleteAsync(User user);
    }
}
