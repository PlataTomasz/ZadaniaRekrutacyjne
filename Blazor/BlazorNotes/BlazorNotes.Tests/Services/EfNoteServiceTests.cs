using BlazorNotes.Contexts;
using BlazorNotes.Model;
using BlazorNotes.Services;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace BlazorNotes.Tests.Services;

[TestFixture]
public class EfNoteServiceTests
{
    private Mock<IDbContextFactory<NotesDbContext>> _mockDbFactory;
    private EfNoteService _efNoteService;

    private static readonly List<Note> InitialNotes = [
        new Note { Id = 1, Title = "Pierwsza notatka", Text = "Notatka numer #1"},
        new Note { Id = 2, Title = "Druga notatka", Text = "Notatka numer #2" },
        new Note { Id = 3, Title = "Trzecia notatka", Text = "Notatka numer #3" }
    ];

    [SetUp]
    public async Task Setup()
    {
        _mockDbFactory = new Mock<IDbContextFactory<NotesDbContext>>();

        var options = new DbContextOptionsBuilder<NotesDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        // Insert seed data into the database using an instance of the context
        using (var context = new NotesDbContext(options))
        {
            foreach (Note note in InitialNotes)
            {
                context.Notes.Add(note);
            }
            context.SaveChanges();
        }
        
        _mockDbFactory.Setup(f => f.CreateDbContextAsync(It.IsAny<CancellationToken>())).ReturnsAsync(() => new NotesDbContext(options));
        
        _efNoteService = new EfNoteService(await _mockDbFactory.Object.CreateDbContextAsync());
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        var notesFromService = await _efNoteService.GetAllAsync();
        Assert.That(notesFromService, Is.Not.Null);
        Assert.That(notesFromService.Count, Is.EqualTo(InitialNotes.Count));
    }
    
    [Test]
    public async Task GetByIdAsync_ShouldReturnProperEntity()
    {
        // Id zaczyna się od 1
        var noteFromService = await _efNoteService.GetByIdAsync(1);
        
        Assert.That(noteFromService, Is.EqualTo(InitialNotes[0]));
    }
    
    [Test]
    public async Task AddAsync_ShouldAddNewUser()
    {
        Note note = new Note { Id = 4, Title = "Inna notatka", Text = "Inna notatka" };
        
        await _efNoteService.AddAsync(note);

        var notes = await _efNoteService.GetAllAsync();
        
        Assert.That(notes, Does.Contain(note));
    }

    [Test]
    public async Task UpdateAsync_ProperlyUpdatesFields()
    {
        // Id zaczyna się od 1
        var note = await _efNoteService.GetByIdAsync(1);
        Assert.That(note, Is.Not.Null);
        note.Title = "Zaktualizowany";
        note.Text = "Zaktualizowana notatka";

        await _efNoteService.UpdateAsync(note);
        var noteAfterUpdate = await _efNoteService.GetByIdAsync(1);
        
        Assert.That(noteAfterUpdate, Is.Not.Null);
        Assert.That(noteAfterUpdate.Title, Is.EqualTo("Zaktualizowany"));
        Assert.That(noteAfterUpdate.Text, Is.EqualTo("Zaktualizowana notatka"));
    }
    
    [Test]
    public async Task UpdateAsync_ThrowsExceptionOnIdChangeAttempt()
    {
        // Id zaczyna się od 1
        var note = await _efNoteService.GetByIdAsync(1);
        Assert.That(note, Is.Not.Null);
        
        note.Id = 255;
        Assert.ThrowsAsync<System.InvalidOperationException>(
            async () => { 
                await _efNoteService.UpdateAsync(note);
            }
        );
    }
    
    [Test] 
    public async Task DeleteAsync_ProperlyDeletesObject()
    {
        var note = _efNoteService.GetByIdAsync(1);
        // Obiekt istniał przed próbą usunięcia
        Assert.That(note, Is.Not.Null);
        
        await _efNoteService.DeleteAsync(note.Id);

        var noteAfterDelete = await _efNoteService.GetByIdAsync(note.Id);
        
        // Obiekt już nie istnieje - został usunięty
        Assert.That(noteAfterDelete, Is.Null);
    }
    
    [Test] 
    public async Task DeleteAsync_ThrowsOnAttemptOfDeletingSameObjectAgain()
    {
        var note = _efNoteService.GetByIdAsync(1);
        // Obiekt istniał przed próbą usunięcia
        Assert.That(note, Is.Not.Null);
        
        // Pierwsze usunięcie
        await _efNoteService.DeleteAsync(note.Id);
        
        // Drugie usunięcie
        Assert.ThrowsAsync<KeyNotFoundException>(async () =>
        {
            await _efNoteService.DeleteAsync(note.Id);
        });
    }
}