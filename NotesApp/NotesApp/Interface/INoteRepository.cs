using Microsoft.Identity.Client;
using NotesApp.Models;

namespace NotesApp.Interface
{
    public interface INoteRepository
    {
        public Task<List<Note>> GetNotes();
        public Task<Note> GetNoteById(int id);
        public Task<List<NoteLabel>> GetLabelsByNote(int noteId);

        Task<bool> PostNote(Note note);

        Task<bool> UpdateNote(int noteId, Note note);   
        Task<bool> DeleteNote(int noteId);
        public Task<bool> NoteExists(int noteId);
        public Task<bool> Save();
    }
}
