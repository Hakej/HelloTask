using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;

namespace HelloTask.Infrastructure.Repositories.InMemory
{
    public class InMemoryTabRepository : ITabRepository
    {
        private static ISet<Tab> _tabs = new HashSet<Tab>();

        public async Task<Tab> GetAsync(Guid id)
            => await Task.FromResult(_tabs.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Tab>> GetAllAsync()
            => await Task.FromResult(_tabs);

        public async Task AddAsync(Tab tab)
        {
            _tabs.Add(tab);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var tab = await GetAsync(id);

            if (tab == null)
            {
                throw new Exception("Tab to delete not found.");
            }

            _tabs.Remove(tab);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Tab tab)
        {
            throw new NotImplementedException();

            await Task.CompletedTask;
        }
    }
}
