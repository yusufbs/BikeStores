using Lp.AngularBlog.Application.Common.Results;

namespace Lp.AngularBlog.Application.Error;

public static class UserError
{
    public static Common.Results.Error InternalServerError 
        => new(ErrorTypeConstant.InternalServerError, "Something went wrong");

    public static Common.Results.Error UserNotFound
        => new(ErrorTypeConstant.NotFound, "User not found");

    public static Common.Results.Error UserAlreadyHasRole
        => new(ErrorTypeConstant.ValidationError, "User already has role");

    public static Common.Results.Error FailedToAssignRole
        => new(ErrorTypeConstant.InternalServerError, "Failed to assign role");

    public static Common.Results.Error UserDoesNotHaveThisRole
        => new(ErrorTypeConstant.ValidationError, "User does not have this role");

    public static Common.Results.Error FailedToRevokeRole
        => new(ErrorTypeConstant.InternalServerError, "Failed to revoke role");

    public static Common.Results.Error CreateInvalidUserUpdateRequestError(IEnumerable<string> errors)
        => new(ErrorTypeConstant.ValidationError, string.Join(", ", errors));
}
