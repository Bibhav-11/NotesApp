using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.DTO;
using NotesApp.Interface;
using NotesApp.Models;
using System.Formats.Asn1;
using System.Reflection;

namespace NotesApp.Repository
{
    public class NoteRepository : INoteRepository
    {
        private readonly NoteContext _context;
        public NoteRepository(NoteContext context)
        {
            _context = context;
        }

        public async Task<bool> DeleteNote(int noteId)
        {
            var note = await _context.Notes.FindAsync(noteId);
            if (note == null) { return false; }
            _context.Notes.Remove(note);
            return await Save();
        }

        public async Task<List<NoteLabel>> GetLabelsByNote(int noteId)
        {
            //return await _context.NoteLabelsCombined.Where(nl => nl.NoteId == noteId).Select(nl => nl.NoteLabel).ToListAsync();
            return await _context.Notes.Where(n => n.Id == noteId).Select(n => n.NoteLabels).FirstAsync();
        }

        public async Task<NoteDTO> GetNoteById(int id)
        {
            //return await _context.Notes.FindAsync(id);

            var note = await _context.Notes.FindAsync(id);
            var noteDTO = new NoteDTO()
            {
                Id = note.Id,
                Title = note.Title,
                Description = note.Description,
            };
            return noteDTO;
        }

        public async Task<List<NoteDTO>> GetNotes()
        {
            //return await _context.Notes.ToListAsync();
            return await _context.Notes.Select(note => new NoteDTO() { Id = note.Id, Description = note.Description, Title = note.Title }).ToListAsync();
        }

        public async Task<bool> NoteExists(int noteId)
        {
            var exists =  await _context.Notes.AnyAsync(n => n.Id == noteId);
            return exists;
        }

        public async Task<bool> PostNote(Note note)
        {
            _context.Notes.Add(note);
            await Save();
            var noteActivity = new NoteActivity()
            {
                NoteId = note.Id,
                Description = "Note Creation"
            };
            _context.NoteActivities.Add(noteActivity);
            return await Save();
        }

        public async Task<bool> Save()
        {
           var saved = await _context.SaveChangesAsync() > 0;
            return saved;
        }

        public async Task<bool> UpdateNote(int noteId, Note note)
        {
            var existingNote = await GetNoteById(noteId);
            if (existingNote == null) { return false; }

            existingNote.Title = note.Title;
            existingNote.Description = note.Description;
            await Save();
            var noteActivity = new NoteActivity()
            {
                NoteId = note.Id,
                Description = "Note Creation"
            };
            _context.NoteActivities.Add(noteActivity);
            return await Save();

        }

        public async Task<NoteActivity> GetLastActivity(int noteId)
        {
            return await _context.NoteActivities.Where(na => na.NoteId == noteId).OrderBy(na => na.NoteId).LastAsync();
        }

        Task<List<Models.NoteLabel>> INoteRepository.GetLabelsByNote(int noteId)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> AddLabel(int id, NoteLabel label)
        {
            var note = await _context.Notes.FindAsync(id);
            note.NoteLabels.Add(label);
            return await Save();
        }
    }
}
