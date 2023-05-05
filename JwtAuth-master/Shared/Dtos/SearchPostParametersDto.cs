namespace Shared.Dtos;

public class SearchPostParametersDto
{
    public string? Username { get; }
    public int? UserId { get; }
    public string? Title { get; }
    public string? Text { get; }

    public SearchPostParametersDto(string? username, int? userId, string? title, string? text)
    {
        Username = username;
        UserId = userId;
        Title = title;
        Text = text;
    }
}