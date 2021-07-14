using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;

namespace HelloTask.Infrastructure.Repositories.InMemory
{
    public class InMemoryBoardRepository : IBoardRepository
    {
        private static readonly ISet<Board> Boards = new HashSet<Board>();

        public async Task<Board> GetAsync(Guid id)
            => await Task.FromResult(Boards.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Board>> GetAllAsync()
            => await Task.FromResult(Boards);

        public async Task AddAsync(Board board)
        {
            Boards.Add(board);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var board = await GetAsync(id);

            if (board == null)
            {
                throw new Exception("Board to delete not found.");
            }

            Boards.Remove(board);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Board board)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
