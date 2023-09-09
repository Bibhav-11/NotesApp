using Microsoft.AspNetCore.Mvc;
using NotesApp.Data;

namespace NotesApp.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class NotesController : ControllerBase
    {
        private readonly NoteContext _context;
        public NotesController(NoteContext context) {
            
           _context = context;
        }

        [HttpGet]
        public ActionResult GetNotes() {
            //using var _context = new NoteContext();
            var notes = _context.Notes;
            return Ok(notes.ToList());
        }

        [HttpGet("{id}")]
        public ActionResult GetNote(int id)
        {
            return Ok(_context.Notes.Find(id));
        }
    }
}
