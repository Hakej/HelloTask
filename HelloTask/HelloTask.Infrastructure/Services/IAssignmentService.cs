using System;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public interface IAssignmentService
    {
        AssignmentDto GetAssignment(Guid id);
        void AddAssignment(string name, string description);
    }
}
