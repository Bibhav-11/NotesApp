using System.Text.Json.Serialization;

namespace NotesApp.Models
{
    public class Note
    {
        public int Id { get; set; }
        public string Title { get; set; } = null!;
        public string Description { get; set; } = null!;

        [JsonIgnore]
        public ICollection<NoteActivity> NoteActivities { get; set; } = new List<NoteActivity>();

        [JsonIgnore]
        public List<NoteLabel> NoteLabels { get; set; } = new List<NoteLabel>();
    }
}
