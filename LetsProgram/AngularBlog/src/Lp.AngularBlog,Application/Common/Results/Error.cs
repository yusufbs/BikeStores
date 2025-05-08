namespace Lp.AngularBlog.Application.Common.Results;

public sealed record Error(string Code, string Message)
{
    internal static Error None => new Error(ErrorTypeConstant.None, string.Empty);
}
