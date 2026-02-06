using Lp.AngularBlog.Application.Common.Results;
using Lp.AngularBlog.Application.DTOs;
using Lp.AngularBlog.Application.Models;

namespace Lp.AngularBlog.Application.Interfaces;

public interface IUserService
{
    Task<Result<PagedResult<UserDto>>> GetAsync(int pageNumber = 1, int pageSize = 10);

    Task<Result<string>> UpdateUserAsync(UserUpdateRequest user);

    Task<Result<string>> DeleteAsync(int Id);

    Task<Result<UserDto>> GetByIdAsync(int Id);

    Task<Result<string>> AssignRoleAsync(AssignRoleRequest request);
    Task<Result<string>> RevokeRoleAsync(AssignRoleRequest roleRequest);
}
