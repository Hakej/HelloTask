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

            return _mapper.Map<Assignment, AssignmentDto>(assignment);
        }

        public async Task<IEnumerable<AssignmentDto>> GetAllAssignmentsAsync()
        {
            var assignments = await _assignmentRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentDto>>(assignments);
        }

        public async Task PostAssignmentAsync(Guid id, Guid ownerId, string name, string description, Guid tabId)
        {
            var owner = await _userRepository.GetAsync(ownerId);
            if (owner == null)
            {
                throw new ArgumentException($"Invalid owner id: user with id: {ownerId} doesn't exist.", nameof(ownerId));
            }

            var tab = await _tabRepository.GetAsync(tabId);
            if (tab == null)
            {
                throw new ArgumentException($"Can't add assignment - tab with id: {tabId} doesn't exist.", nameof(tabId));
            }

            var assignment = new Assignment(id, owner, name, description, tabId);
            await _assignmentRepository.AddAsync(assignment);
            await Task.CompletedTask;
        }
    }
}
