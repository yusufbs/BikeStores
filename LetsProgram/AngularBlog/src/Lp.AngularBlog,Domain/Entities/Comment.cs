namespace Lp.AngularBlog_Domain.Entities;

public class Comment
{
    public int Id { get; set; }
    public required string Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;

    public int UserId { get; set; }
    public required User User { get; set; }

    public int BlogId { get; set; }
    public required Blog Blog { get; set; }
}
