using BlazorNotes.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotes.Contexts;

public class NotesDbContext(DbContextOptions<NotesDbContext> options) : DbContext(options)
{
    public DbSet<Note> Notes { get; set; }
}