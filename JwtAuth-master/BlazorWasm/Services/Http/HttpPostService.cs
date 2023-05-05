using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using Shared.Dtos;
using Shared.Models;

namespace BlazorWasm.Services.Http;

public class HttpPostService : IPostService
{
    private readonly HttpClient client;
    
    public HttpPostService(HttpClient client)
    {
        this.client = client;
        client.BaseAddress = new Uri("https://localhost:7130");
    }

    public async Task CreatePostAsync(PostCreationDto dto)
    {
        HttpResponseMessage response = await client.PostAsJsonAsync("/Post", dto);
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }

    public async Task<ICollection<Post>> GetAsync(string? userName, int? userId, string? title, string? text)
    {
        //client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", JwtAuthService.Jwt);
        HttpResponseMessage response = await client.GetAsync("https://localhost:7130/Post");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        ICollection<Post> posts = JsonSerializer.Deserialize<ICollection<Post>>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return posts;
    }

    public async Task<PostBasicDto> GetByIdAsync(int id)
    {
        HttpResponseMessage response = await client.GetAsync($"/Post/{id}");
        string content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        PostBasicDto post = JsonSerializer.Deserialize<PostBasicDto>(content, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        })!;
        return post;
    }
    
    public async Task DeleteAsync(int id)
    {
        HttpResponseMessage response = await client.DeleteAsync($"Post/{id}");
        if (!response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            throw new Exception(content);
        }
    }
}