using NotesApp.Models;
using System.Reflection.Emit;

namespace NotesApp.Interface
{
    public interface INoteLabelRepository
    {
        Task<List<NoteLabel>> GetLabels();
        Task<NoteLabel> GetLabelById(int id);
        Task<bool> CreateLabel(NoteLabel label);
        Task<bool> UpdateLabel(int labelId, NoteLabel label);

        Task<bool> DeleteLabel(int labelId);
        Task<bool> LabelExists(int labelId);

        Task<bool> Saved();

    }
}
