using System.ComponentModel.DataAnnotations;

namespace MegaCity.Models;

public class Building
{
    public int? Id { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Address { get; set; }

    [Required]
    public string Index { get; set; }

    [Required]
    public string SectorCode { get; set; }

    [Required]
    public int EnergyUnits { get; set; }

    [Required]
    public int EnergyUnitMax { get; set; }
}