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

        public TabService(IMapper mapper, ITabRepository tabRepository, IAssignmentRepository assignmentRepository)
        {
            _mapper = mapper;
            _tabRepository = tabRepository;
            _assignmentRepository = assignmentRepository;
        }

        public async Task<TabDto> GetTabAsync(Guid id)
        {
            var tab = await _tabRepository.GetAsync(id);

            return _mapper.Map<Tab, TabDto>(tab);
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

        public async Task PostTabAsync(Guid id, string name)
        {
            var tab = new Tab(id, name);

            await _tabRepository.AddAsync(tab);
             
            await Task.CompletedTask;
        }
    }
}
