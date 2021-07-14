using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface ITabService : IService
    {
        Task<TabDetailsDto> GetTabAsync(Guid id);
        Task<IEnumerable<TabDto>> GetAllTabsAsync();
        Task PostTabAsync(Guid id, Guid ownerId, string name, Guid boardId);
        Task<IEnumerable<AssignmentDto>> GetAssignmentsFromTabAsync(Guid tabId);
    }
}
