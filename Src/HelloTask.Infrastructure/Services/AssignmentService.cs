using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public class AssignmentService : IAssignmentService
    {
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly ITabRepository _tabRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository, ITabRepository tabRepository)
        {
            _mapper = mapper;
            _assignmentRepository = assignmentRepository;
            _tabRepository = tabRepository;
        }

        public async Task<AssignmentDto> GetAssignmentAsync(Guid id)
        {
            var assignment = await _assignmentRepository.GetAsync(id);

            return _mapper.Map<Assignment, AssignmentDto>(assignment);
        }

        public async Task<IEnumerable<AssignmentDto>> GetAllAssignmentsAsync()
        {
            var assignments = await _assignmentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentDto>>(assignments);
        }

        public async Task PostAssignmentAsync(Guid id, string name, string description, Guid tabId)
        {
            var assignment = new Assignment(id, name, description, tabId);
            var tab = await _tabRepository.GetAsync(tabId);

            if (tab == null)
            {
                throw new Exception($"Can't add assignment - tab with id: {tabId} doesn't exist.");
            }

            await _assignmentRepository.AddAsync(assignment);
             
            await Task.CompletedTask;
        }
    }
}
