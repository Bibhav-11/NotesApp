using Microsoft.Extensions.Primitives;
using System.Text.Json.Serialization;

namespace NotesApp.Models
{
    public class NoteHistory
    {
        public int Id { get; set; }
        public DateTime ActivityTime { get; set; } = DateTime.Now;
        public string Description { get; set; } = null!;

        [JsonIgnore]
        public Note? Note { get; set; }
    }
}