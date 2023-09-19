using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Interface;
using NotesApp.Models;

namespace NotesApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteLabelsController : ControllerBase
    {
        private readonly INoteLabelRepository _repository;

        public NoteLabelsController(INoteLabelRepository repository)
        {
            _repository = repository;
        }

        // GET: api/NoteLabels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteLabel>>> GetNoteLabels()
        {
            return await _repository.GetLabels();
        }

        // GET: api/NoteLabels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteLabel>> GetNoteLabel(int id)
        {
            var noteLabel = await _repository.GetLabelById(id);

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

            await _repository.UpdateLabel(id, noteLabel);

            return NoContent();
        }

        // POST: api/NoteLabels
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<NoteLabel>> PostNoteLabel(NoteLabel noteLabel)
        {
           await _repository.CreateLabel(noteLabel);

            return CreatedAtAction("GetNoteLabel", new { id = noteLabel.Id }, noteLabel);
        }

        // DELETE: api/NoteLabels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteNoteLabel(int id)
        {
            var noteLabel = await _repository.GetLabelById(id);
            if (noteLabel == null)
            {
                return NotFound();
            }

            await _repository.DeleteLabel(id);

            return NoContent();
        }
    }
}
