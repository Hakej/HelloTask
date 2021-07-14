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
        private static readonly ISet<User> Users = new HashSet<User>();

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(Users.SingleOrDefault(x => x.Id == id));

        public async Task<User> GetByEmailAsync(string email)
            => await Task.FromResult(Users.SingleOrDefault(x => x.Email == email));

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Task.FromResult(Users);

        public async Task AddAsync(User user)
        {
            Users.Add(user);
            await Task.CompletedTask;
        }

        public async Task RemoveAsync(Guid id)
        {
            var user = await GetAsync(id);

            if (user == null)
            {
                throw new Exception("User to delete not found.");
            }

            Users.Remove(user);

            await Task.CompletedTask;
        }

        public async Task UpdateAsync(User user)
        {
            await Task.CompletedTask;
            throw new NotImplementedException();
        }
    }
}