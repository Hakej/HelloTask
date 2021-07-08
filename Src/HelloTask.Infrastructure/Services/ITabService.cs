using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface ITabService : IService
    {
        Task<TabDto> GetTabAsync(Guid id);
        Task<IEnumerable<TabDto>> GetAllTabsAsync();
        Task PostTabAsync(Guid id, string name);
        Task<IEnumerable<AssignmentDto>> GetAssignmentsFromTabAsync(Guid tabId);
    }
}
