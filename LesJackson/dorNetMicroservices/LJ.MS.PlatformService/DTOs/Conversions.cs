using LJ.MS.PlatformService.Models;

namespace LJ.MS.PlatformService.DTOs;

public static class Conversions
{
    public static PlatformReadDto ToDto(this Platform platform)
    {
        return new PlatformReadDto
        {
            Cost = platform.Cost,
            Id = platform.Id,
            Name = platform.Name,
            Publisher = platform.Publisher
        };
    }

    public static IEnumerable<PlatformReadDto> ToDto(this IEnumerable<Platform> platforms)
    {
        return platforms.Select(platform => ToDto(platform));
    }

    public static Platform ToModel(this PlatformCreateDto platform) 
    {
        return new Platform
        {
            Publisher = platform.Publisher,
            Cost = platform.Cost,
            Name = platform.Name,
        };
    }
}
