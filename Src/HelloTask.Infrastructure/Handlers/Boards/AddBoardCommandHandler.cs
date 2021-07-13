using System;
using System.Threading.Tasks;
using HelloTask.Infrastructure.Commands;
using HelloTask.Infrastructure.Commands.Boards;
using HelloTask.Infrastructure.Services;

namespace HelloTask.Infrastructure.Handlers.Boards
{
    public class AddBoardCommandHandler : ICommandHandler<AddBoardCommand>
    {
        private readonly IBoardService _boardService;

        public AddBoardCommandHandler(IBoardService boardService)
        {
            _boardService = boardService;
        }

        public async Task HandleAsync(AddBoardCommand command)
        {
            await _boardService.PostBoardAsync(Guid.NewGuid(), command.Name);
        }
    }
}
