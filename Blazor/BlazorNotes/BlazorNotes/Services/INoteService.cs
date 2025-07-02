using BlazorNotes.Model;

namespace BlazorNotes.Services;

public interface INoteService
{
    // Create
    public Task AddAsync(Note note);
    
    // Read
    public Task<List<Note>> GetAllAsync();
    public Task<Note> GetByIdAsync(int noteId);
    
    // Update
    public Task UpdateAsync(Note note);
    
    // Delete
    public Task DeleteAsync(int noteId);
}