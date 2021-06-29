using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloTask.Data;
using HelloTask.ModelDtos;
using HelloTask.Models;

namespace HelloTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BoardsController : ControllerBase
    {
        private readonly HelloTaskDbContext _context;

        public BoardsController(HelloTaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BoardDto>>> GetBoard()
        {
            var boards = await _context.Boards.ToListAsync();

            var boardDtos = boards.Select(board => new BoardDto() {Id = board.Id, Name = board.Name}).ToList();

            return boardDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BoardDto>> GetBoard(int id)
        {
            var board = _context.Boards
                .FirstOrDefault(t => t.Id == id);

            if (board == null)
            {
                return NotFound();
            }

            var boardDto = new BoardDto() { Id = board.Id, Name = board.Name };

            return boardDto;
        }

        [HttpGet("{id}/Tabs")]
        public async Task<ActionResult<IEnumerable<TabDto>>> GetTabsFromBoard(int id)
        {
            var board = _context.Boards
                .Include(c => c.Tabs)
                .FirstOrDefault(t => t.Id == id);

            if (board == null)
            {
                return NotFound();
            }
            var tabDtos = board.Tabs.Select(tab => new TabDto() { Id = tab.Id, Name = tab.Name }).ToList();

            return tabDtos;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<BoardDto>> PutBoard(int id, BoardDto board)
        {
            if (id != board.Id)
            {
                return BadRequest("Ids in request and body don't match.");
            }

            var foundBoard = _context.Boards
                .FirstOrDefault(b => b.Id == id);

            if (foundBoard == null)
            {
                return NotFound();
            }

            foundBoard.Name = board.Name;

            await _context.SaveChangesAsync();

            return board;
        }

        [HttpPost]
        public async Task<ActionResult<BoardDto>> PostBoard(BoardDto board)
        {
            var newBoard = new Board() { Name = board.Name };

            _context.Boards.Add(newBoard);
            await _context.SaveChangesAsync();

            board.Id = newBoard.Id;

            return CreatedAtAction(nameof(GetBoard), new { id = newBoard.Id }, board);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBoard(int id)
        {
            var board = await _context.Boards.FindAsync(id);
            if (board == null)
            {
                return NotFound();
            }

            _context.Boards.Remove(board);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
