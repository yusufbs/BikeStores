using Microsoft.AspNet.Identity.EntityFramework;

namespace AM.CoreIdentity.Domain.Users;

public class UserRole : IdentityUserRole<string>
{
    public User User { get; set; }
    public Role Role { get; set; }
}
