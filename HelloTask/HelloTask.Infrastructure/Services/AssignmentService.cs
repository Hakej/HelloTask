using System;
using System.Linq;
using AutoMapper;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Extensions;

namespace HelloTask.Infrastructure.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IAssignmentRepository assignmentRepository, IMapper mapper)
        {
            _assignmentRepository = assignmentRepository;
            _mapper = mapper;
        }

        public AssignmentDto GetAssignment(Guid id)
        {
            var assignments = _assignmentRepository.GetAll();
            var assignment = assignments.GetRandomElement();
            //var assignment = _assignmentRepository.Get(id);

            return _mapper.Map<Assignment, AssignmentDto>(assignment);
        }

        public void AddAssignment(string name, string description)
        {
            var assignment = new Assignment(name, description);
            _assignmentRepository.Add(assignment);
        }
    }
}
