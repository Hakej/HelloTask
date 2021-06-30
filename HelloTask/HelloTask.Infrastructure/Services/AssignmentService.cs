using System;
using System.Linq;
using System.Threading.Tasks;
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

        public async Task<AssignmentDto> GetAssignmentAsync(Guid id)
        {
            var assignments = await _assignmentRepository.GetAllAsync();
            var assignment = assignments.GetRandomElement();
            //var assignment = _assignmentRepository.GetAsync(id);

            return _mapper.Map<Assignment, AssignmentDto>(assignment);
        }

        public async Task PostAssignmentAsync(string name, string description)
        {
            var assignment = new Assignment(name, description);
            
            await _assignmentRepository.AddAsync(assignment);
             
            await Task.CompletedTask;
        }
    }
}
