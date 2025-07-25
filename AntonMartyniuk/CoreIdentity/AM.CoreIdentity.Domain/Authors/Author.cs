﻿using AM.CoreIdentity.Domain.Books;
using AM.CoreIdentity.Domain.Users;

namespace AM.CoreIdentity.Domain.Authors;

public class Author : IAuditableEntity
{
    public required Guid Id { get; set; }

    public required string Name { get; set; }

    public List<Book> Books { get; set; } = [];

    public string? UserId { get; set; }

    public User? User { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? UpdatedAtUtc { get; set; }
}
