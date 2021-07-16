using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Core.Domain;

namespace HelloTask.Core.Repositories
{
    public interface ITabRepository : IRepository
    {
        Task<Tab> GetAsync(Guid id);
        Task<IEnumerable<Tab>> GetAllAsync();
        Task AddAsync(Tab tab);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Tab tab);
    }
}
