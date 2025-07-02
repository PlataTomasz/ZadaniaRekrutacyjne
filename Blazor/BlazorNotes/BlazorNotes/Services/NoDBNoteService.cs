using BlazorNotes.Model;

namespace BlazorNotes.Services;

public class NoDBNoteService : INoteService
{
    private List<Note> _notes = [
        new Note(0,"First", "First note"),
        new Note(1,"Second", "Second note"),
        new Note(2,"Third", "Fourth note"),
        new Note(3,"Fourth", "Fourth note"),
    ];
    
    public Task AddAsync(Note note)
    {

        return Task.CompletedTask;
    }

    public Task<List<Note>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Note> GetByIdAsync(int noteId)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Note note)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(int noteId)
    {
        throw new NotImplementedException();
    }
}