//using Microsoft.AspNetCore.Mvc;
//using Microsoft.EntityFrameworkCore;
//using NotesApp.Data;
//using NotesApp.Models;

//namespace NotesApp.Controllers
//{
//    [ApiController]
//    [Route("/api/[controller]")]
//    public class NotesController : ControllerBase
//    {
//        private readonly NoteContext _context;
//        public NotesController(NoteContext context) {

//           _context = context;
//        }

//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Note>>> GetNotes() {
//            //using var _context = new NoteContext();
//            var notes = await _context.Notes.ToListAsync();
//            return notes;
//        }

//        [HttpGet("{id}")]
//        public async Task<ActionResult<Note>> GetNote(int id) => await _context.Notes.FindAsync(id);

//        [HttpPut("{id}")]
//        public async Task<ActionResult> Update(int id, Note note)
//        {
//            if (id != note.Id) return BadRequest();
//            var existingNote = await _context.Notes.FirstOrDefaultAsync(n => n.Id == id);
//            if (existingNote == null) { return BadRequest(); };

//            existingNote.Title = note.Title;
//            existingNote.Description = note.Description;

//            var noteHistory = new NoteHistory()
//            {
//                Description = "Note Update"
//            };
//            _context.NoteHistories.Add(noteHistory);

//            //_context.Notes.Update(note);

//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        [HttpPost]
//        public async Task<ActionResult> CreateNote(Note note)
//        {
//            _context.Notes.Add(note);
//            await _context.SaveChangesAsync();
//            var noteHistory = new NoteHistory()
//            {
//                Description = "Note Creation"
//            };
//            _context.NoteHistories.Add(noteHistory);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        [HttpGet("{id}/histories")]
//        public async Task<ActionResult<List<NoteHistory>>> GetHistoryByNote(int id)
//        {
//            return NoContent();

//        }

//        [HttpGet("{id}/histories/last")]
//        public async Task<ActionResult<NoteHistory>> GetLastHistoryByNote(int id)
//        {

//            return NoContent();
//        }

//        [HttpDelete("{id}")]
//        public async Task<ActionResult> DeleteNote(int id)
//        {
//            var note = await _context.Notes.FindAsync(id);
//            if(note == null) return NotFound();
//            _context.Notes.Remove(note);
//            await _context.SaveChangesAsync();
//            return NoContent();
//        }

//        [HttpGet("{noteId}/labels")]
//        public async Task<ActionResult<List<NoteLabel>>> GetLabelsByNote(int noteId)
//        {
//            return await _context.Notes.Where(n => n.Id == noteId).Select(n => n.NoteLabels).FirstAsync();
//            //return await _context.NoteLabels.ToListAsync();
//        }
//    }
//}


using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Interface;
using NotesApp.Models;
using NotesApp.Repository;
using System.Runtime.CompilerServices;

namespace NotesApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotesController : ControllerBase
    {
        private INoteRepository _notesRepository;
        public NotesController(INoteRepository repository) {
            _notesRepository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Note>>> GetNotes()
        {
            return await _notesRepository.GetNotes();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Note>> GetNote(int id)
        {
            if(! await _notesRepository.NoteExists(id)) { return NotFound();  }
            return await _notesRepository.GetNoteById(id);
        }

        [HttpPost]
        public async Task<ActionResult<Note>> PostNote(Note note)
        {
            if(note == null) { return BadRequest(); }
            await _notesRepository.PostNote(note);
            return CreatedAtAction(nameof(GetNote), new { id = note.Id }, note);

        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNote(int id, Note note)
        {
            if (id != note.Id) return BadRequest();
            var existingNote = await _notesRepository.GetNoteById(id);
            if (existingNote == null) { return NotFound(); }
            await _notesRepository.UpdateNote(id, note);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            var note = await _notesRepository.GetNoteById(id);
            if (note == null) { return NotFound();  }
            await _notesRepository.DeleteNote(id);
            return NoContent();
        }
    }



}