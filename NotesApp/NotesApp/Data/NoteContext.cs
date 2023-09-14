using Microsoft.EntityFrameworkCore;
using NotesApp.Models;

namespace NotesApp.Data
{
    public class NoteContext : DbContext
    {
        public NoteContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Note> Notes { get; set; }

        public DbSet<NoteActivity> NoteActivities { get; set; }

        public DbSet<NoteHistory> NoteHistories { get; set; }

        public DbSet<NoteLabel> NoteLabels { get; set; }

        public DbSet<NoteLabelCombined> NoteLabelsCombined { get; set; }

    }
}
