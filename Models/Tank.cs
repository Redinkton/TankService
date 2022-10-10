using System;
using System.ComponentModel.DataAnnotations;

namespace MyTank.Models;

public class Tank
{
    public int Id { get; set; }
    [Required] //свойство Name обязательное
    public string? Name { get; set; }

    public string? Description { get; set; }

    public int MinVolume { get; set; }
    public int MaxVolume { get; set; }
    public int CurrentVolume { get; set; }
}