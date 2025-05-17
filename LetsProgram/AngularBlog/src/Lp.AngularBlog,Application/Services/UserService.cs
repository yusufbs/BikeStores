using Lp.AngularBlog.Application.Common.Results;
using Lp.AngularBlog.Application.DTOs;
using Lp.AngularBlog.Application.Error;
using Lp.AngularBlog.Application.Interfaces;
using Lp.AngularBlog.Application.Models;
using Lp.AngularBlog.Application.Validators;
using Lp.AngularBlog.Domain.Interfaces;

namespace Lp.AngularBlog.Application.Services;

public class UserService (
    IUserRepository userRepository, 
    IUserRoleRepository userRoleRepository,
    UserUpdateRequestValidator userUpdateRequestValidator,
    IUnitOfWork unitOfWork) : IUserService
{
    public async Task<Result<string>> AssignRoleAsync(AssignRoleRequest request)
    {
        try
        {
            var userHasRole = await userRoleRepository.HasRoleAsync(request.UserId, request.RoleId);
            if (userHasRole)
            {
                return Result.Failure<string>(UserError.UserAlreadyHasRole);
            }

            var result = await userRoleRepository.AddAsync(request.UserId, request.RoleId);
            return result 
                ? Result.Success("Role assigned successfully") 
                : Result.Failure<string>(UserError.FailedToAssignRole);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result<string>> DeleteAsync(int Id)
    {
        try
        {
            var user = await userRepository.GetByIdAsync(Id);
            if (user is null) 
            {
                return Result.Failure<string>(UserError.UserNotFound);
            }
            userRepository.Delete(user);
            await unitOfWork.CommitAsync();

            return Result.Success("User deleted successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result<PagedResult<UserDto>>> GetAsync(int pageNumber = 1, int pageSize = 10)
    {
        try
        {
            var users = await userRepository.GetAllAsync();
            var totalCount = users.Count();
            var pagedItems = users
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .Select(user => new UserDto(
                    user.Id,
                    user.Email,
                    user.UserName,
                    user.UserRoles.Select(x => x.Role!.Name).ToList()
                    ))
                .ToList();

            var pagedResult = new PagedResult<UserDto>
            {
                Items = pagedItems,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };

            return Result.Success(pagedResult);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result<UserDto>> GetByIdAsync(int Id)
    {
        try
        {
            var user = await userRepository.GetByIdAsync(Id);
            if (user is null)
            {
                return Result.Failure<UserDto>(UserError.UserNotFound);
            }

            var userDetails = new UserDto(user.Id, user.Email, user.UserName, user.UserRoles.Select(x => x.Role!.Name).ToList());    
            return Result.Success(userDetails);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result<string>> RevokeRoleAsync(AssignRoleRequest roleRequest)
    {
        try
        {
            var userHasRole = await userRoleRepository.HasRoleAsync(roleRequest.UserId, roleRequest.RoleId);
            if (!userHasRole)
            {
                return Result.Failure<string>(UserError.UserDoesNotHaveThisRole);
            }

            var result = await userRoleRepository.RemoveAsync(roleRequest.UserId, roleRequest.RoleId);
            return result
                ? Result.Success("Role revoked successfully")
                : Result.Failure<string>(UserError.FailedToRevokeRole);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }

    public async Task<Result<string>> UpdateUserAsync(UserUpdateRequest userUpdateRequest)
    {
        try
        {
            var validationResult = await userUpdateRequestValidator.ValidateAsync(userUpdateRequest);
            if (!validationResult.IsValid) {
                var errors = validationResult.Errors.Select(x => x.ErrorMessage);
                return Result.Failure<string>(UserError.CreateInvalidUserUpdateRequestError(errors));
            }

            var user = await userRepository.GetByIdAsync(userUpdateRequest.Id);
            if (user is null)
            {
                return Result.Failure<string>(UserError.UserNotFound);
            }

            user.UserName = userUpdateRequest.Username;
            user.Email = userUpdateRequest.Email;
            userRepository.Update(user);
            await unitOfWork.CommitAsync();

            return Result.Success("User updated successfully");
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
