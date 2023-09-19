using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;

namespace NotesApp.Models
{
    public class NoteLabel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        [JsonIgnore]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}
