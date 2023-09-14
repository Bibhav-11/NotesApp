using Microsoft.EntityFrameworkCore;

namespace NotesApp.Models
{
    [Keyless]
    public class NoteLabelCombined
    {
        public int NoteId { get; set; } 
        public int NoteLabelId { get; set; }
        public Note Note { get; set; }
        public NoteLabel NoteLabel { get; set; }   
    }
}
