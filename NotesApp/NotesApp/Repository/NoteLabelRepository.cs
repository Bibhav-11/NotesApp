using Microsoft.EntityFrameworkCore;
using NotesApp.Data;
using NotesApp.Interface;
using NotesApp.Models;

namespace NotesApp.Repository
{
    public class NoteLabelRepository : INoteLabelRepository
    {
        private readonly NoteContext _context;
        public NoteLabelRepository(NoteContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateLabel(NoteLabel label)
        {
            _context.NoteLabels.Add(label);
            return await Saved();
        }


        public async Task<bool> DeleteLabel(int labelId)
        {
            var label = await GetLabelById(labelId);
            _context.NoteLabels.Remove(label);
            return await Saved();
        }

        public async Task<NoteLabel> GetLabelById(int id)
        {
            return await _context.NoteLabels.FindAsync(id);
        }

        public async Task<List<NoteLabel>> GetLabels()
        {
            return await _context.NoteLabels.ToListAsync();
        }

        public async Task<bool> LabelExists(int labelId)
        {
           return await _context.NoteLabels.AnyAsync(label => label.Id == labelId);
        }

        public async Task<bool> Saved()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateLabel(int labelId, NoteLabel label)
        {
            _context.Entry(label).State = EntityState.Modified;
            return await Saved();
        }
    }
}
