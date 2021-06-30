using System;
using System.Linq;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Extensions;

namespace HelloTask.Infrastructure.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;

        public AssignmentService(IAssignmentRepository assignmentRepository)
        {
            _assignmentRepository = assignmentRepository;
        }

        public AssignmentDto GetAssignment(Guid id)
        {
            var assignments = _assignmentRepository.GetAll();
            var assignment = assignments.GetRandomElement();
            //var assignment = _assignmentRepository.Get(id);

            return new AssignmentDto()
            {
                Id = assignment.Id,
                Name = assignment.Name,
                Description = assignment.Description
            };
        }

        public void AddAssignment(string name, string description)
        {
            var assignment = new Assignment(name, description);
            _assignmentRepository.Add(assignment);
        }
    }
}
