namespace Shared.Dtos;

public class PostBasicDto
{
    public int Id { get; }
    public string OwnerName { get; }
    public string Title { get; }
    public string Text { get; }
    
    public PostBasicDto(int id, string ownerName, string title, string text)
    {
        Id = id;
        OwnerName = ownerName;
        Title = title;
        Text = text;
    }
}