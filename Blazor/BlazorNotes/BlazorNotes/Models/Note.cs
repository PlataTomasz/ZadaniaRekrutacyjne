using System.ComponentModel.DataAnnotations;

namespace BlazorNotes.Model;

public class Note()
{
    [Key]
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

    public override bool Equals(object obj)
    {
        if (obj is Note other)
        {
            return Id.Equals(other.Id) && Title.Equals(other.Title) && Text.Equals(other.Text); 
        }
        return false;
    }
    
    public override int GetHashCode()
    {
        unchecked // Allow overflow, ensures better distribution
        {
            int hash = 17;
            hash = hash * 23 + Id.GetHashCode();
            hash = hash * 23 + (Title?.GetHashCode() ?? 0);
            hash = hash * 23 + (Text?.GetHashCode() ?? 0);
            return hash;
        }
    }
}