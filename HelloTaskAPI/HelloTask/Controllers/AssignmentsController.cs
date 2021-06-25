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
        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAssignment(int id, AssignmentsDto assignments)
        {
            var oldAssignment = _context.Assignments.FirstOrDefault(t => t.Id == id);

            if (oldAssignment == null)
            {
                return NotFound();
            }

            oldAssignment.Name = assignments.Name;
            oldAssignment.Description = assignments.Description;

            _context.Entry(oldAssignment).State = EntityState.Modified;
            
            await _context.SaveChangesAsync();

            return NoContent();
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
        public async Task<ActionResult<Tab>> AddAssignment(int tabId, AssignmentsDto assignments)
        {
            var tab = _context.Tabs
                .Include(c => c.Assignments)
                .FirstOrDefault(t => t.Id == tabId);

            if (tab == null)
            {
                return NotFound();
            }

            var newAssignment = new Models.Assignment() { Name = assignments.Name, Description = assignments.Description };
            tab.Assignments.Add(newAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("AddAssignment", newAssignment);
        }
    }
}
