namespace AM.CoreIdentity.Infrastructure.Configure;

public class AuthConfiguration
{
    public required string Key { get; init; }
    public required string Issuer { get; init; }
    public required string Audience { get; init; }
}
