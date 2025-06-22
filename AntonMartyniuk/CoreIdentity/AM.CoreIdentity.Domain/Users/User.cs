﻿using Microsoft.AspNet.Identity.EntityFramework;

namespace AM.CoreIdentity.Domain.Users;

public class User : IdentityUser, IAuditableEntity
{
    public ICollection<UserClaim> Claims { get; set; }

    public ICollection<UserRole> UserRoles { get; set; }

    public ICollection<UserLogin> UserLogins { get; set; }

    public ICollection<UserToken> UserTokens { get; set; }

    public DateTime CreatedAtUtc { get; set; }

    public DateTime? UpdatedAtUtc { get; set; }
}
