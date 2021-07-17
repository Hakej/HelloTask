using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Domain;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Extensions;

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

            return _mapper.Map<TabDetailsDto>(tab);
        }

        public async Task<IEnumerable<TabDto>> GetAllTabsAsync()
        {
            var tabs = await _tabRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<TabDto>>(tabs);
        }
        
        public async Task<IEnumerable<AssignmentDto>> GetAssignmentsFromTabAsync(Guid tabId)
        {
            var assignments = await _assignmentRepository.GetAllAsync();
            var foundAssignments = assignments.Where(x => x.Tab.Id == tabId);

            return _mapper.Map<IEnumerable<AssignmentDto>>(foundAssignments);
        }

        public async Task PostTabAsync(Guid id, Guid ownerId, string name, Guid boardId)
        {
            var owner = await _userRepository.GetOrFailAsync(ownerId);
            var board = await _boardRepository.GetOrFailAsync(boardId);
            var tab = new Tab(id, owner, name, board);
            
            await _tabRepository.AddAsync(tab);
        }
    }
}
