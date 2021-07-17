using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface IUserService : IService
    {
        Task<UserDto> GetUserAsync(Guid id);
        Task<UserDto> GetUserByEmailAsync(string email);
        Task<IEnumerable<UserDto>> GetAllUsersAsync();
        Task RegisterUserAsync(Guid id, string email, string username, string password, string role);
        Task LoginAsync(string email, string password);
        Task DeleteAsync(Guid userId);
        Task ChangeUsername(Guid userId, string newUsername);
    }
}
