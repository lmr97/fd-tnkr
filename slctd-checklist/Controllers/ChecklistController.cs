using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SlctdChecklist.Models;

namespace SlctdChecklist.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class ChecklistController : ControllerBase
    {
        private readonly ChecklistDbContext _context;

        public ChecklistController(ChecklistDbContext context)
        {
            _context = context;
        }

        // GET: api/Checklist/submissions?employee=martin&startDate=2024-10-12&endDate=2026-12-23
        [HttpGet]
        [Route("submissions")]
        public async Task<ActionResult<IEnumerable<ChecklistSubmission>>> GetSubmissions(
            [FromQuery] string? employee,
            [FromQuery] Shift? shift,
            [FromQuery] DateOnly? startDate,
            [FromQuery] DateOnly? endDate
        )
        {
            // default range to be ranged over last month
            endDate ??= DateOnly.FromDateTime(DateTime.Now);
            startDate ??= DateOnly.FromDateTime(DateTime.Now.AddMonths(-1));

            var query = _context.Submissions
                .Where((sub) => sub.Date >= startDate && sub.Date <= endDate);
            
            if (employee is not null)
            {
                query = query.Where((sub) => sub.Employee == employee);
            }

            if (shift is not null)
            {
                query = query.Where((sub) => sub.Shift == shift);
            }

            return await query.ToListAsync();
        }

        // GET: api/Checklist?shift=AM&version=2
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Checklist>>> GetChecklist(
            [FromQuery] int? version,
            [FromQuery] Shift shift=Shift.AM
        )
        {
            version ??= _context.Checklists.Max((checklist) => checklist.Version);
            
            return await _context.Checklists
                .Where(ckl => ckl.Shift == shift && ckl.Version == version)
                .Include(ckl => ckl.Segments)
                .ThenInclude(seg => seg.TasksToDo)
                .AsSplitQuery()  // can help performance
                .ToListAsync();
        }

        [HttpPut]
        public async Task<IActionResult> PutChecklistSubmission([FromQuery] int id, ChecklistSubmission checklistSubmission)
        {
            if (id != checklistSubmission.Id)
            {
                return BadRequest();
            }

            _context.Entry(checklistSubmission).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecklistSubmissionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> PutChecklist([FromQuery] int id, Checklist checklist)
        {
            if (id != checklist.Id)
            {
                return BadRequest();
            }

            _context.Entry(checklist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChecklistExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Checklist
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ChecklistSubmission>> PostChecklistSubmission(ChecklistSubmission checklistSubmission)
        {
            _context.Submissions.Add(checklistSubmission);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChecklistSubmission", new { id = checklistSubmission.Id }, checklistSubmission);
        }

        [HttpPost]
        public async Task<ActionResult<ChecklistSubmission>> PostChecklist(ChecklistSubmission checklist)
        {
            _context.Checklists.Add(checklist);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChecklistSubmission", new { id = checklist.Id }, checklist);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteChecklist([FromQuery] int id)
        {
            var checklist = await _context.Checklists.FindAsync(id);
            if (checklist == null)
            {
                return NotFound();
            }

            _context.Checklists.Remove(checklist);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChecklistSubmissionExists(int id)
        {
            return _context.Submissions.Any(e => e.Id == id);
        }

        private bool ChecklistExists(int id)
        {
            return _context.Checklists.Any(e => e.Id == id);
        }
    }
}
