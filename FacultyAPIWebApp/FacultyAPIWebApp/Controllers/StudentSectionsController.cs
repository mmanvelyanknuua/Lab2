using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FacultyAPIWebApp.Models;

namespace FacultyAPIWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentSectionsController : ControllerBase
    {
        private readonly FacultyAPIContext _context;

        public StudentSectionsController(FacultyAPIContext context)
        {
            _context = context;
        }

        // GET: api/StudentSections
        [HttpGet]
        public async Task<ActionResult<IEnumerable<StudentSection>>> GetStudentSections()
        {
          if (_context.StudentSections == null)
          {
              return NotFound();
          }
            return await _context.StudentSections.ToListAsync();
        }

        // GET: api/StudentSections/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentSection>> GetStudentSection(int id)
        {
          if (_context.StudentSections == null)
          {
              return NotFound();
          }
            var studentSection = await _context.StudentSections.FindAsync(id);

            if (studentSection == null)
            {
                return NotFound();
            }

            return studentSection;
        }

        // PUT: api/StudentSections/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentSection(int id, StudentSection studentSection)
        {
            if (id != studentSection.Id)
            {
                return BadRequest();
            }

            _context.Entry(studentSection).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentSectionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetStudentSection", new { id = studentSection.Id }, studentSection);
        }

        // POST: api/StudentSections
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<StudentSection>> PostStudentSection(StudentSection studentSection)
        {
          if (_context.StudentSections == null)
          {
              return Problem("Entity set 'FacultyAPIContext.StudentSections'  is null.");
          }
            _context.StudentSections.Add(studentSection);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStudentSection", new { id = studentSection.Id }, studentSection);
        }

        // DELETE: api/StudentSections/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentSection(int id)
        {
            if (_context.StudentSections == null)
            {
                return NotFound();
            }
            var studentSection = await _context.StudentSections.FindAsync(id);
            if (studentSection == null)
            {
                return NotFound();
            }

            _context.StudentSections.Remove(studentSection);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool StudentSectionExists(int id)
        {
            return (_context.StudentSections?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
