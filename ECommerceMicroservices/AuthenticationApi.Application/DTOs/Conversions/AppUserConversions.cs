using AuthenticationApi.Domain.Entities;

namespace AuthenticationApi.Application.DTOs.Conversions;

public static class AppUserConversions
{
    public static GetUserDTO ToGetUserDTO(this AppUser appUser) => new GetUserDTO
    (
        appUser.Id,
        appUser.Name,
        appUser.TelephoneNumber,
        appUser.Address,
        appUser.Email,
        appUser.Role
    );

    public static AppUser ToAppUser(this AppUserDTO appUserDTO) => new AppUser
    {
        Name = appUserDTO.Name,
        TelephoneNumber = appUserDTO.TelephoneNumber,
        Address = appUserDTO.Address,
        Email = appUserDTO.Email,
        Password = BCrypt.Net.BCrypt.HashPassword(appUserDTO.Password),
        Role = appUserDTO.Role
    };
}
