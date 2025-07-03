using BlazorNotes.Contexts;
using BlazorNotes.Model;
using Microsoft.EntityFrameworkCore;

namespace BlazorNotes.Services;

public class EfNoteService(NotesDbContext context) : INoteService
{
    public async Task AddAsync(Note note)
    {
        context.Notes.Add(note);
        await context.SaveChangesAsync();
    }

    public async Task<List<Note>> GetAllAsync()
    {
        return await context.Notes.ToListAsync();
    }

    public async Task<Note> GetByIdAsync(int id)
    {
        return await context.Notes.FindAsync(id);
    }

    public async Task UpdateAsync(Note note)
    {
        context.Notes.Update(note);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int noteId)
    {
        var note = await context.Notes.FindAsync(noteId);
        if (note != null)
        {
            context.Remove(note);
            await context.SaveChangesAsync();
        }
        else
        {
            throw new KeyNotFoundException();
        }
    }
}