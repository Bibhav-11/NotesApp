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

        public DbSet<NoteHistory> NoteHistories { get; set; }

    }
}
