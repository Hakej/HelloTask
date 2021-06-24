using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
    public class TabsController : ControllerBase
    {
        private readonly HelloTaskDbContext _context;

        public TabsController(HelloTaskDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tab>>> GetTabs()
        {
            return await _context.Tabs.Include(c => c.Assignments).ToListAsync();
        }

        [HttpGet("{id}")]   
        public async Task<ActionResult<Tab>> GetTab(int id)
        {
            var tab = _context.Tabs
                .Include(c => c.Assignments)
                .FirstOrDefault(t => t.Id == id);

            if (tab == null)
            {
                return NotFound();
            }

            return tab;
        }

        [HttpPut("ChangeTabName/{id}")]
        public async Task<IActionResult> ChangeName(int id, TabDto tab)
        {
            var foundTab = _context.Tabs
                .FirstOrDefault(t => t.Id == id);

            if (foundTab == null)
            {
                return NotFound();
            }

            foundTab.Name = tab.Name;
            
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<Tab>> PostTab(TabDto tabDto)
        {
            var newTab = new Tab() {Name = tabDto.Name};

            _context.Tabs.Add(newTab);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTab", new { id = newTab.Id }, newTab);
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
