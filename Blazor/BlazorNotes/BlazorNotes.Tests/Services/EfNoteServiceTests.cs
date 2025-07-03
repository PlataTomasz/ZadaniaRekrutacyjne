using BlazorNotes.Contexts;
using BlazorNotes.Model;
using BlazorNotes.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework.Legacy;

namespace BlazorNotes.Tests.Services;

[TestFixture]
public class EfNoteServiceTests
{
    private Mock<IDbContextFactory<NotesDbContext>> _mockDbFactory;

    private static readonly List<Note> InitialNotes = [
        new Note { Id = 1, Title = "Pierwsza note", Text = "Notatka numer #1"},
        new Note { Id = 2, Title = "Druga note", Text = "Notatka numer #2" },
        new Note { Id = 3, Title = "Trzecia note", Text = "Notatka numer #3" }
    ];

    [SetUp]
    public void Setup()
    {
        _mockDbFactory = new Mock<IDbContextFactory<NotesDbContext>>();

        var options = new DbContextOptionsBuilder<NotesDbContext>()
            .UseInMemoryDatabase(databaseName: "NotesDbTests")
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
    }

    [Test]
    public async Task GetAllAsync_ShouldReturnAllEntities()
    {
        var efNoteService = new EfNoteService(await _mockDbFactory.Object.CreateDbContextAsync());
        
        var notesFromService = await efNoteService.GetAllAsync();
        Assert.That(notesFromService, Is.Not.Null);
        Assert.That(notesFromService.Count, Is.EqualTo(InitialNotes.Count));
    }
    
    [Test]
    public async Task AddAsync_ShouldAddNewUser()
    {
        Note note = new Note { Id = 4, Title = "Inna notatka", Text = "Inna notatka" };
        
        var efNoteService = new EfNoteService(await _mockDbFactory.Object.CreateDbContextAsync());
        await efNoteService.AddAsync(note);

        var notes = await efNoteService.GetAllAsync();
        
        Assert.That(notes, Does.Contain(note));
    }
    
    
}