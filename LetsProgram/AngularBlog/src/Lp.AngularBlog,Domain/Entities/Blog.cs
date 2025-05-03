namespace Lp.AngularBlog.Domain.Entities;

public class Blog
{
    public int Id { get; set; }
    public required string  Title { get; set; }
    public required string Content { get; set; }
    public required string Image { get; set; }
    public required DateTime CreatedAt { get; set; } = DateTime.Now;
    public required DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public required User User { get; set; }

    public List<Comment>? Comments { get; set; }
}
