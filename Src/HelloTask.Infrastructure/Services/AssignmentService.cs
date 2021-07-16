using System;
using System.Collections.Generic;
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
        private readonly ITabRepository _tabRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public AssignmentService(IMapper mapper, IAssignmentRepository assignmentRepository, ITabRepository tabRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _assignmentRepository = assignmentRepository;
            _tabRepository = tabRepository;
            _userRepository = userRepository;
        }

        public async Task<AssignmentDto> GetAssignmentAsync(Guid id)
        {
            var assignment = await _assignmentRepository.GetAsync(id);

            return _mapper.Map<AssignmentDto>(assignment);
        }

        public async Task<IEnumerable<AssignmentDto>> GetAllAssignmentsAsync()
        {
            var assignments = await _assignmentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<AssignmentDto>>(assignments);
        }

        public async Task PostAssignmentAsync(Guid id, Guid ownerId, string name, string description, Guid tabId)
        {
            var owner = await _userRepository.GetOrFailAsync(ownerId);
            var tab = await _tabRepository.GetOrFailAsync(tabId);

            var assignment = new Assignment(id, owner, name, description, tab);
            await _assignmentRepository.AddAsync(assignment);
            await Task.CompletedTask;
        }
    }
}
