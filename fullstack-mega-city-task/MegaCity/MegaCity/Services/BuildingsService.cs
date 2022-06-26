using MegaCity.DbContexts.Entities;
using MegaCity.Models;
using MegaCity.Repositories;

namespace MegaCity.Services;

public class BuildingsService : IBuildingsService
{
    private readonly IBuildingsRepository _repository;

    public BuildingsService(IBuildingsRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Building>> FindAll()
    {
        return (await _repository.FindAll()).Select(Map);
    }

    public async Task<Building?> FindBuildingById(int id)
    {
        return (await _repository.FindAll()).Select(Map).FirstOrDefault(x => x.Id == id);
    }

    public async Task<Building> Create(Building building)
    {
        var result = await _repository.Create(Map(building));
        if(result != null)
        {
            return Map(result);
        }
        return null;
    }

    public async Task<bool> Update(int buildingId, Building building)
    {
        var data = await _repository.FindAll();
        var buildingDbo = data.FirstOrDefault(x => x.Id == buildingId);
        
        if (buildingDbo != null)
        {
            MapUpdate(building, buildingDbo);
            await _repository.SaveChangesAsync();
            return true;
        }
        return false;
    }

    private static Building Map(BuildingDbo building)
    {
        return new Building
        {
            Address = building.Address,
            EnergyUnitMax = building.EnergyUnitMax,
            EnergyUnits = building.EnergyUnits,
            Id = building.Id,
            Index = building.Index,
            Name = building.Name,
            SectorCode = building.SectorCode,
        };
    }

    private static BuildingDbo Map(Building building)
    {
        return new BuildingDbo
        {
            Address = building.Address,
            EnergyUnitMax = building.EnergyUnitMax,
            EnergyUnits = building.EnergyUnits,
            Index = building.Index,
            Name = building.Name,
            SectorCode = building.SectorCode,
        };
    }

    private static void MapUpdate(Building building, BuildingDbo buildingDbo)
    {
        buildingDbo.Address = building.Address;
        buildingDbo.EnergyUnitMax = building.EnergyUnitMax;
        buildingDbo.EnergyUnits = building.EnergyUnits;
        buildingDbo.Index = building.Index;
        buildingDbo.Name = building.Name;
        buildingDbo.SectorCode = building.SectorCode;
    }
}