using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using HelloTask.Core.Models;
using HelloTask.Core.Repositories;
using HelloTask.Infrastructure.DTO;
using HelloTask.Infrastructure.Extensions;

namespace HelloTask.Infrastructure.Services
{
    public class BoardService : IBoardService
    {
        private readonly IBoardRepository _boardRepository;
        private readonly ITabRepository _tabRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public BoardService(IMapper mapper, IBoardRepository boardRepository, ITabRepository tabRepository, IUserRepository userRepository)
        {
            _mapper = mapper;
            _boardRepository = boardRepository;
            _tabRepository = tabRepository;
            _userRepository = userRepository;
        }

        public async Task<BoardDetailsDto> GetBoardAsync(Guid id)
        {
            var board = await _boardRepository.GetAsync(id);

            return _mapper.Map<BoardDetailsDto>(board);
        }

        public async Task<IEnumerable<BoardDto>> GetAllBoardsAsync()
        {
            var boards = await _boardRepository.GetAllAsync();

            return _mapper.Map<IEnumerable<BoardDto>>(boards);
        }
        
        public async Task<IEnumerable<TabDto>> GetTabsFromBoardAsync(Guid boardId)
        {
            var tabs = await _tabRepository.GetAllAsync();
            var tabsFromBoard = tabs.Where(x => x.Board.Id == boardId);

            return _mapper.Map<IEnumerable<TabDto>>(tabsFromBoard);
        }

        public async Task PostBoardAsync(Guid id, Guid ownerId, string name)
        {
            var owner = await _userRepository.GetOrFailAsync(ownerId);
            var board = new Board(id, owner, name);
            
            await _boardRepository.AddAsync(board);
        }
    }
}
