using System;
using System.Threading.Tasks;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;

namespace HelloTask.Infrastructure.Extensions
{
    public static class RepositoryExtensions
    {
        public static async Task<Tab> GetOrFailAsync(this ITabRepository tabRepository,
                     Guid boardId)
                 {
                     var tab = await tabRepository.GetAsync(boardId);
                     if (tab == null)
                     {
                         throw new ArgumentException($"Tab with id: {boardId} doesn't exist.", nameof(boardId));
                     }
         
                     return tab;
                 }
            
        public static async Task<User> GetOrFailAsync(this IUserRepository userRepository,
            Guid boardId)
        {
            var user = await userRepository.GetAsync(boardId);
            if (user == null)
            {
                throw new ArgumentException($"User with id: {boardId} doesn't exist.", nameof(boardId));
            }

            return user;
        }
        
        public static async Task<Board> GetOrFailAsync(this IBoardRepository boardRepository,
            Guid boardId)
        {
            var board = await boardRepository.GetAsync(boardId);
            if (board == null)
            {
                throw new ArgumentException($"Board with id: {boardId} doesn't exist.", nameof(boardId));
            }

            return board;
        }
    }
}