namespace NotesApp.Models
{
    public class NoteActivity
    {
            public int Id { get; set; }
            public DateTime ActivityTime { get; set; } = DateTime.Now;
            public int NoteId { get; set; }
            public string Description { get; set; } = null!;
}
}
