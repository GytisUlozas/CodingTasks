namespace MegaCity.DbContexts.Entities;

public class BuildingDbo
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string Index { get; set; }
    public string SectorCode { get; set; }
    public int EnergyUnits { get; set; }
    public int EnergyUnitMax { get; set; }
}