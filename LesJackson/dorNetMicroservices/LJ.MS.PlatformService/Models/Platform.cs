﻿using System.ComponentModel.DataAnnotations;

namespace LJ.MS.PlatformService.Models;

public class Platform
{
    [Key]
    [Required]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Publisher { get; set; }

    [Required]
    public string Cost { get; set; }
}
