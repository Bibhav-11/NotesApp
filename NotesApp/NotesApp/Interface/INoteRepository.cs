using Microsoft.Identity.Client;
using NotesApp.DTO;
using NotesApp.Models;

namespace NotesApp.Interface
{
    public interface INoteRepository
    {
        public Task<List<NoteDTO>> GetNotes();
        public Task<NoteDTO> GetNoteById(int id);
        public Task<List<NoteLabel>> GetLabelsByNote(int noteId);

        Task<bool> PostNote(Note note);

        Task<bool> UpdateNote(int noteId, Note note);   
        Task<bool> DeleteNote(int noteId);

        Task<bool> AddLabel(int id, NoteLabel label);

        Task<NoteActivity> GetLastActivity(int noteId);
        public Task<bool> NoteExists(int noteId);
        public Task<bool> Save();
    }
}
