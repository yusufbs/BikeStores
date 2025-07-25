using Microsoft.AspNetCore.Identity;

namespace AM.CoreIdentity.Domain.Users;

public class Role : IdentityRole<string>
{
    public ICollection<UserRole> UserRoles { get; set; }
    public ICollection<RoleClaim> RoleClaims { get; set; }
}
