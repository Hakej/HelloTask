using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            return _mapper.Map<User, UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<User>, IEnumerable<UserDto>>(users);
        }

        public async Task RegisterUserAsync(Guid id, string email, string username, string password, string role)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user != null)
            {
                throw new Exception($"User with email '{email}' already exists.");
            }

            user = new User(id, email, username, role, password, Guid.NewGuid().ToString());
            await _userRepository.AddAsync(user);
        }
    }
}
