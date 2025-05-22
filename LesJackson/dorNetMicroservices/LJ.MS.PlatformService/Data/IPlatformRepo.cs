using LJ.MS.PlatformService.Models;

namespace LJ.MS.PlatformService.Data;

public interface IPlatformRepo
{
    bool SaveChanges();

    IEnumerable<Platform> GetAllPlatforms();

    Platform? GetPlatformById(int id);

    void CreatePlatform(Platform platform);
}
