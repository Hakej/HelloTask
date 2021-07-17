using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Domain;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Exceptions;
using HelloTask.Infrastructure.Extensions;

namespace HelloTask.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IEncrypter _encrypter;

        public UserService(IMapper mapper, IUserRepository userRepository, IEncrypter encrypter)
        {
            _mapper = mapper;
            _userRepository = userRepository;
            _encrypter = encrypter;
        }

        public async Task<UserDto> GetUserAsync(Guid id)
        {
            var user = await _userRepository.GetAsync(id);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> GetUserByEmailAsync(string email)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            return _mapper.Map<UserDto>(user);
        }

        public async Task<IEnumerable<UserDto>> GetAllUsersAsync()
        {
            var users = await _userRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<UserDto>>(users);
        }

        public async Task RegisterUserAsync(Guid id, string email, string username, string password, string role)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user != null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.EmailInUse, $"User with email '{email}' already exists.");
            }

            var salt = _encrypter.GetSalt(password);
            var hash = _encrypter.GetHash(password, salt);

            user = new User(id, email, username, role, hash, salt);
            await _userRepository.AddAsync(user);
        }

        public async Task LoginAsync(string email, string password)
        {
            var user = await _userRepository.GetByEmailAsync(email);

            if (user == null)
            {
                throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials, "Invalid credentials.");
            }
            
            var hash = _encrypter.GetHash(password, user.Salt);

            if (user.Password == hash)
            {
                return;
            }

            throw new ServiceException(Exceptions.ErrorCodes.InvalidCredentials, "Invalid credentials.");
        }

        public async Task DeleteAsync(Guid userId)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            await _userRepository.DeleteAsync(user);
        }

        public async Task ChangeUsername(Guid userId, string newUsername)
        {
            var user = await _userRepository.GetOrFailAsync(userId);
            user.SetUsername(newUsername);
        }
    }
}
