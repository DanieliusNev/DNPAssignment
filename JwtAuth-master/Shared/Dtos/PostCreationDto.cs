namespace Shared.Dtos;

public class PostCreationDto
{
    public int AuthorId { get; }
    public string Title { get; }
    public string Text { get; }

    public PostCreationDto(int authorId, string title, string text)
    {
        AuthorId = authorId;
        Title = title;
        Text = text;
    }
}