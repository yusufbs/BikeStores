using LJ.MS.PlatformService.Data;
using LJ.MS.PlatformService.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace LJ.MS.PlatformService.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PlatformsController : ControllerBase
{
    private readonly IPlatformRepo _platformRepo;

    public PlatformsController(IPlatformRepo platformRepo)
    {
        _platformRepo = platformRepo;
    }

    [HttpGet]
    public ActionResult<IEnumerable<PlatformReadDto>> GetPlatforms()
    {
        var platformItems = _platformRepo.GetAllPlatforms();

        return Ok(platformItems.ToDto());
    }

    [HttpGet("{id}", Name= "GetPlatformById")]
    public ActionResult<PlatformReadDto> GetPlatformById(int id)
    {
        var platform = _platformRepo.GetPlatformById(id);
        if (platform is null)
        {
            return NotFound();
        }

        return Ok(platform.ToDto());
    }
}
