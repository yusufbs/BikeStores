﻿using LJ.MS.PlatformService.Models;

namespace LJ.MS.PlatformService.Data;

public class PlatformRepo : IPlatformRepo
{
    private readonly AppDbContext _context;

    public PlatformRepo(AppDbContext context)
    {
        _context = context;
    }
    public void CreatePlatform(Platform platform)
    {
        if (platform == null)
        {
            throw new ArgumentNullException(nameof(platform));
        }
        _context.Platforms.Add(platform);
    }

    public IEnumerable<Platform> GetAllPlatforms()
    {
        return _context.Platforms;
    }

    public Platform? GetPlatformById(int id)
    {
        return _context.Platforms.FirstOrDefault(p => p.Id == id);
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }
}
