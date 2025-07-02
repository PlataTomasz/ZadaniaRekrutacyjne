using System.ComponentModel.DataAnnotations;

namespace BlazorNotes.Model;

public class Note()
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    
    [Required]
    public string Text { get; set; }

    public Note(string title, string text) : this()
    {
        this.Title = title;
        this.Text = text;
    }
    
    public Note(int id, string title, string text) : this(title, text)
    {
        this.Id = id;
    }
}