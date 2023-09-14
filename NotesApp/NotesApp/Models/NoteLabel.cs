using System.Runtime.CompilerServices;

namespace NotesApp.Models
{
    public class NoteLabel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

       
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
