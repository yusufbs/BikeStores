﻿namespace Lp.AngularBlog.Domain.Entities;

public class User
{
    public int Id { get; set; }
    public required string UserName { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }

    public List<UserRole>? UserRoles { get; set; }
    public List<Blog>? Blogs { get; set; }
    public List<Comment>? Comments { get; set; }
}
