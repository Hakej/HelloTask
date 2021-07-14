using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;

namespace HelloTask.Infrastructure.Services
{
    public class TabService : ITabService
    {
        private readonly ITabRepository _tabRepository;
        private readonly IAssignmentRepository _assignmentRepository;
        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;
        private readonly IBoardRepository _boardRepository;

        public TabService(IMapper mapper, ITabRepository tabRepository, IAssignmentRepository assignmentRepository, IUserRepository userRepository, IBoardRepository boardRepository)
        {
            _mapper = mapper;
            _tabRepository = tabRepository;
            _assignmentRepository = assignmentRepository;
            _userRepository = userRepository;
            _boardRepository = boardRepository;
        }

        public async Task<TabDetailsDto> GetTabAsync(Guid id)
        {
            var tab = await _tabRepository.GetAsync(id);

            return _mapper.Map<Tab, TabDetailsDto>(tab);
        }

        public async Task<IEnumerable<TabDto>> GetAllTabsAsync()
        {
            var tabs = await _tabRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<Tab>, IEnumerable<TabDto>>(tabs);
        }
        
        public async Task<IEnumerable<AssignmentDto>> GetAssignmentsFromTabAsync(Guid tabId)
        {
            var assignments = await _assignmentRepository.GetAllAsync();
            var foundAssignments = assignments.Where(x => x.TabId == tabId);

            return _mapper.Map<IEnumerable<Assignment>, IEnumerable<AssignmentDto>>(foundAssignments);
        }

        public async Task PostTabAsync(Guid id, Guid ownerId, string name, Guid boardId)
        {
            var owner = await _userRepository.GetAsync(ownerId);
            if (owner == null)
            {
                throw new ArgumentException($"Invalid owner id: user with id: {ownerId} doesn't exist.", nameof(ownerId));
            }

            var board = await _boardRepository.GetAsync(boardId);
            if (board == null)
            {
                throw new ArgumentException($"Invalid board id: board with id: {boardId} doesn't exist.", nameof(boardId));
            }

            var tab = new Tab(id, name, boardId);
            await _tabRepository.AddAsync(tab);
            await Task.CompletedTask;
        }
    }
}
