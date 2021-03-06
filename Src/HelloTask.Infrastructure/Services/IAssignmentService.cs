using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface IAssignmentService : IService
    {
        Task<AssignmentDto> GetAssignmentAsync(Guid id);
        Task<IEnumerable<AssignmentDto>> GetAllAssignmentsAsync();
        Task PostAssignmentAsync(Guid id, Guid ownerId, string name, string description, Guid tabId);
    }
}
