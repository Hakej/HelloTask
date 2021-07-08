using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Core.Models;

namespace HelloTask.Core.Repositories
{
    public interface IAssignmentRepository : IRepository
    {
        Task<Assignment> GetAsync(Guid id);
        Task<IEnumerable<Assignment>> GetAllAsync();
        Task AddAsync(Assignment assignment);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Assignment assignment);
    }
}
