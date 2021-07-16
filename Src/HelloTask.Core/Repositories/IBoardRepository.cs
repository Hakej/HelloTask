using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Core.Domain;

namespace HelloTask.Core.Repositories
{
    public interface IBoardRepository : IRepository
    {
        Task<Board> GetAsync(Guid id);
        Task<IEnumerable<Board>> GetAllAsync();
        Task AddAsync(Board tab);
        Task RemoveAsync(Guid id);
        Task UpdateAsync(Board board);
    }
}
