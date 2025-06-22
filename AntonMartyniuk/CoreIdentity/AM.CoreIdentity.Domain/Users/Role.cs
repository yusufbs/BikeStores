using Microsoft.AspNet.Identity.EntityFramework;

namespace AM.CoreIdentity.Domain.Users;

public class Role : IdentityRole
{
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }
}
