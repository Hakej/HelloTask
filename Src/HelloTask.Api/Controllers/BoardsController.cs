using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Tabs;
using HelloTask.Infrastructure.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HelloTask.Api.Controllers
{
    public class BoardsController : ApiControllerBase
    {
        private readonly IBoardService _boardService;

        public BoardsController(IBoardService boardService,
            ICommandDispatcher commandDispatcher) : base(commandDispatcher)
        {
            _boardService = boardService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var assignment = await _boardService.GetBoardAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            return Json(assignment);
        }

        [HttpGet("Tabs/{boardId}")]
        public async Task<IActionResult> GetTabs(Guid boardId)
        {
            var board = await _boardService.GetBoardAsync(boardId);

            if (board == null)
            {
                return NotFound();
            }

            var foundTabs = await _boardService.GetTabsFromBoardAsync(boardId);

            return Json(foundTabs);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var boards = await _boardService.GetAllBoardsAsync();
            return Json(boards);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PostTab command)
        {
            await DispatchAsync(command);

            return Created("boards", new object());
        }
    }
}
