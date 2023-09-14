using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Models;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteLabelsController : ControllerBase
    {
        private readonly NoteContext _context;

        public NoteLabelsController(NoteContext context)
        {
            _context = context;
        }

        // GET: api/NoteLabels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteLabel>>> GetNoteLabels()
        {
          if (_context.NoteLabels == null)
          {
              return NotFound();
          }
            return await _context.NoteLabels.ToListAsync();
        }

        // GET: api/NoteLabels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteLabel>> GetNoteLabel(int id)
        {
          if (_context.NoteLabels == null)
          {
              return NotFound();
          }
            var noteLabel = await _context.NoteLabels.FindAsync(id);

            if (noteLabel == null)
            {
                return NotFound();
            }

            return noteLabel;
        }

        // PUT: api/NoteLabels/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutNoteLabel(int id, NoteLabel noteLabel)
        {
            if (id != noteLabel.Id)
            {
                return BadRequest();
            }

            _context.Entry(noteLabel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NoteLabelExists(id))
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

        // POST: api/NoteLabels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoteLabel>> PostNoteLabel(NoteLabel noteLabel)
        {
          if (_context.NoteLabels == null)
          {
              return Problem("Entity set 'NoteContext.NoteLabels'  is null.");
          }
            _context.NoteLabels.Add(noteLabel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetNoteLabel", new { id = noteLabel.Id }, noteLabel);
        }

        // DELETE: api/NoteLabels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteLabel(int id)
        {
            if (_context.NoteLabels == null)
            {
                return NotFound();
            }
            var noteLabel = await _context.NoteLabels.FindAsync(id);
            if (noteLabel == null)
            {
                return NotFound();
            }

            _context.NoteLabels.Remove(noteLabel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool NoteLabelExists(int id)
        {
            return (_context.NoteLabels?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
