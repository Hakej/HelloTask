using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTask.Core.Domain;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.Exceptions;

namespace HelloTask.Infrastructure.Repositories.InMemory
{
    public class InMemoryTabRepository : ITabRepository
    {
        private static readonly ISet<Tab> Tabs = new HashSet<Tab>();

        public async Task<Tab> GetAsync(Guid id)
            => await Task.FromResult(Tabs.SingleOrDefault(x => x.Id == id));

        public async Task<IEnumerable<Tab>> GetAllAsync()
            => await Task.FromResult(Tabs);

        public async Task AddAsync(Tab tab)
        {
            Tabs.Add(tab);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var tab = await GetAsync(id);

            if (tab == null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.TabNotFound, "Tab to delete not found.");
            }

            Tabs.Remove(tab);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(Tab tab)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}
