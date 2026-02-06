using Lp.AngularBlog.Application.Common.Results;

namespace Lp.AngularBlog.Application.Error;

public static class AuthError
{
    public static Common.Results.Error InvalidRegisterRequest 
        => new (ErrorTypeConstant.ValidationError, "Invalid register request");

    public static Common.Results.Error UserAlreadyExists 
        => new (ErrorTypeConstant.ValidationError, "User already exists");

    public static Common.Results.Error InvalidLoginRequest
        => new(ErrorTypeConstant.ValidationError, "Invalid login request");

    public static Common.Results.Error UserNotFound
        => new(ErrorTypeConstant.NotFound, "User not found");

    public static Common.Results.Error InvalidPassword
        => new(ErrorTypeConstant.ValidationError, "Password is incorrect");

    public static Common.Results.Error CreateInvalidLoginRequestError(IEnumerable<string> errors) 
        => new(ErrorTypeConstant.ValidationError, string.Join(", ", errors));

    public static Common.Results.Error CreateInvalidRegisterRequestError(IEnumerable<string> errors)
        => new(ErrorTypeConstant.ValidationError, string.Join(", ", errors));
}
