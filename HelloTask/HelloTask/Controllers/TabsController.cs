using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HelloTask.Data;
using HelloTask.Infrastructure.DTO;
using HelloTask.ModelDtos;
using HelloTask.Models;

namespace HelloTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TabsController : ControllerBase
    {
        private readonly HelloTaskDbContext _context;

        public TabsController(HelloTaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TabDto>>> GetTabs()
        {
            var tabs = await _context.Tabs.ToListAsync();

            var tabDtos = tabs.Select(tab => new TabDto() { Id = tab.Id, Name = tab.Name, BoardId = tab.BoardId }).ToList();

            return tabDtos;
        }

        [HttpGet("{id}")]   
        public async Task<ActionResult<TabDto>> GetTab(int id)
        {
            var tab = _context.Tabs.FirstOrDefault(t => t.Id == id);

            if (tab == null)
            {
                return NotFound();
            }

            var tabDto = new TabDto() { Id = tab.Id, Name = tab.Name, BoardId = tab.BoardId};

            return tabDto;
        }

        [HttpGet("{id}/Assignments")]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignmentsFromTab(int id)
        {
            var tab = _context.Tabs
                .Include(t => t.Assignments)
                .FirstOrDefault(t => t.Id == id);

            if (tab == null)
            {
                return NotFound();
            }

            var assignmentDtos = tab.Assignments.Select(a => new AssignmentDto() { Id = a.Id, Name = a.Name , Description = a.Description }).ToList();

            return assignmentDtos;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<TabDto>> PutTab(int id, TabDto tab)
        {
            if (id != tab.Id)
            {
                return BadRequest("Ids in request and body don't match.");
            }

            var foundTab = _context.Tabs
                .FirstOrDefault(t => t.Id == id);

            if (foundTab == null)
            {
                return NotFound();
            }

            foundTab.Name = tab.Name;

            if (foundTab.BoardId != tab.BoardId)
            {
                var newBoard = await _context.Boards.FindAsync(tab.BoardId);

                if (newBoard == null)
                {
                    return NotFound();
                }

                foundTab.Board = newBoard;
                foundTab.BoardId = newBoard.Id;
            }

            _context.Entry(foundTab).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return tab;
        }

        [HttpPost("{boardId}")]
        public async Task<ActionResult<TabDto>> PostTab(int boardId, TabDto tabDto)
        {
            var board = _context.Boards
                .Include(c => c.Tabs)
                .FirstOrDefault(b => b.Id == boardId);

            if (board == null)
            {
                return NotFound();
            }
            
            var newTab = new Tab() { Name = tabDto.Name };

            board.Tabs.Add(newTab);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTab), new { id = newTab.Id }, tabDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTab(int id)
        {
            var tab = _context.Tabs
                .Include(c => c.Assignments)
                .FirstOrDefault(t => t.Id == id);

            if (tab == null)
            {
                return NotFound();
            }
            
            _context.Tabs.Remove(tab);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
