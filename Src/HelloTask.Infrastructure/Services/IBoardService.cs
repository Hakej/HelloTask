using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface IBoardService : IService
    {
        Task<BoardDetailsDto> GetBoardAsync(Guid id);
        Task<IEnumerable<BoardDto>> GetAllBoardsAsync();
        Task PostBoardAsync(Guid id, Guid ownerId, string name);
        Task<IEnumerable<TabDto>> GetTabsFromBoardAsync(Guid tabId);
    }
}
