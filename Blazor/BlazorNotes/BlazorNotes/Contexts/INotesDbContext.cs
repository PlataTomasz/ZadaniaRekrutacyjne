using BlazorNotes.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotes.Contexts;

public interface INotesDbContext
{
    public DbSet<Note> Notes { get; set; }
}