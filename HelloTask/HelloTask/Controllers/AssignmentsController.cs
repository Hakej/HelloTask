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
    public class AssignmentsController : ControllerBase
    {
        private readonly HelloTaskDbContext _context;

        public AssignmentsController(HelloTaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AssignmentDto>>> GetAssignments()
        {
            var assignments = await _context.Assignments.ToListAsync();

            var assignmentDtos = assignments.Select(assignment => new AssignmentDto() { Id = assignment.Id, Name = assignment.Name, Description = assignment.Description, TabId = assignment.TabId }).ToList();

            return assignmentDtos;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AssignmentDto>> GetAssignment(int id)
        {
            var assignment = _context.Assignments
                .FirstOrDefault(a => a.Id == id);

            if (assignment == null)
            {
                return NotFound();
            }

            var assignmentDto = new AssignmentDto()
                {Id = assignment.Id, Name = assignment.Name, Description = assignment.Description, TabId = assignment.TabId };

            return assignmentDto;
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<AssignmentDto>> PutAssignment(int id, AssignmentDto assignment)
        {
            if (id != assignment.Id)
            {
                return BadRequest("Ids in request and body don't match.");
            }

            var foundAssignment = _context.Assignments.FirstOrDefault(t => t.Id == id);

            if (foundAssignment == null)
            {
                return NotFound();
            }

            foundAssignment.Name = assignment.Name;
            foundAssignment.Description = assignment.Description;

            if (foundAssignment.TabId != assignment.TabId)
            {
                var newTab = await _context.Tabs.FindAsync(assignment.TabId);

                if (newTab == null)
                {
                    return NotFound();
                }

                foundAssignment.Tab = newTab;
                foundAssignment.TabId = newTab.Id;
            }

            _context.Entry(foundAssignment).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return assignment;
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAssignment(int id)
        {
            var assignment = await _context.Assignments.FindAsync(id);

            if (assignment == null)
            {
                return NotFound();
            }

            _context.Assignments.Remove(assignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpPost("{tabId}")]
        public async Task<ActionResult<TabDto>> PostAssignment(int tabId, AssignmentDto assignment)
        {
            var tab = _context.Tabs
                .Include(c => c.Assignments)
                .FirstOrDefault(t => t.Id == tabId);

            if (tab == null)
            {
                return NotFound();
            }

            var newAssignment = new Assignment() { Name = assignment.Name, Description = assignment.Description };

            tab.Assignments.Add(newAssignment);
            await _context.SaveChangesAsync();

            assignment.Id = newAssignment.Id;

            return CreatedAtAction(nameof(GetAssignment), new {id = newAssignment.Id}, assignment);
        }
    }
}
