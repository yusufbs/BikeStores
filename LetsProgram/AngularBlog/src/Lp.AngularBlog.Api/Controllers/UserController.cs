using Lp.AngularBlog.Api.Extensions;
using Lp.AngularBlog.Application.Interfaces;
using Lp.AngularBlog.Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lp.AngularBlog.Api.Controllers;

public class UserController (IUserService userService) : BaseApiController
{
    //[Authorize]
    [HttpGet]
    public async Task<IResult> GetUsers([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10)
    {
        var users = await userService.GetAsync(pageNumber, pageSize);
        return users.ToHttpResponse();
    }

    [HttpPut]
    public async Task<IResult> UpdateUser([FromBody] UserUpdateRequest userUpdateRequest)
    {
        var result = await userService.UpdateUserAsync(userUpdateRequest);
        return result.ToHttpResponse();
    }

    [HttpDelete ("{id}")]
    public async Task<IResult> DeleteUser(int id)
    {
        var result = await userService.DeleteAsync(id);
        return result.ToHttpResponse();
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetUserById(int id)
    {
        var result = await userService.GetByIdAsync(id);
        return result.ToHttpResponse();
    }

    [HttpPost("assign-role")]
    public async Task<IResult> AssignRole([FromBody] AssignRoleRequest roleRequest)
    {
        var result = await userService.AssignRoleAsync(roleRequest);
        return result.ToHttpResponse();
    }

    [HttpDelete("revoke-role")]
    public async Task<IResult> RevokeRole([FromBody] AssignRoleRequest roleRequest)
    {
        var result = await userService.RevokeRoleAsync(roleRequest);
        return result.ToHttpResponse();
    }
}
