using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface IAssignmentService
    {
        Task<AssignmentDto> GetAssignmentAsync(Guid id);
        Task PostAssignmentAsync(string name, string description);
    }
}
