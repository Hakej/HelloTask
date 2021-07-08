using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;

namespace HelloTask.Infrastructure.Repositories.InMemory
{
    public class InMemoryUserRepository : IUserRepository
    {
        private static ISet<User> _users = new HashSet<User>();

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetByEmailAsync(string email)
            => await Task.FromResult(_users.SingleOrDefault(x => x.Email == email));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(_users);

        public async Task AddAsync(User user)
        {
            _users.Add(user);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);

            if (user == null)
            {
                throw new Exception("User to delete not found.");
            }

            _users.Remove(user);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            throw new NotImplementedException();

            await Task.CompletedTask;
        }
    }
}