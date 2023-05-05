using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Authorization;

namespace Shared.Models;

public class Post
{
    [Key]
    public int PostId { get; set; }
    public User Author { get; private set; }
    
    [MaxLength(30)]
    public string Title { get; private set; }
    public string Text { get; set; }

    public Post(User author, string title, string text)
    {
        Author = author;
        Title = title;
        Text = text;
    }
    
    private Post(){}
}