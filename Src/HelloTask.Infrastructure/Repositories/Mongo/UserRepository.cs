using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Core.Domain;
using HelloTask.Core.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace HelloTask.Infrastructure.Repositories.Mongo
{
    public class UserRepository : IUserRepository, IMongoRepository
    {
        private readonly IMongoDatabase _mongoDatabase;

        public UserRepository(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task<User> GetAsync(Guid id)
            => await Users.AsQueryable().Where(x => x.Id == id).FirstOrDefaultAsync();

        public async Task<User> GetByEmailAsync(string email)
            => await Users.AsQueryable().Where(x => x.Email == email).FirstOrDefaultAsync();

        public async Task<IEnumerable<User>> GetAllAsync()
            => await Users.AsQueryable().ToListAsync();

        public async Task AddAsync(User user)
            => await Users.InsertOneAsync(user);

        public async Task UpdateAsync(User user)
            => await Users.ReplaceOneAsync(x => x.Id == user.Id, user);
        
        public async Task DeleteAsync(User user)
            => await Users.DeleteOneAsync(x => x.Id == user.Id);
        
        private IMongoCollection<User> Users => _mongoDatabase.GetCollection<User>("Users");
    }
}