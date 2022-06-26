using MegaCity.DbContexts.Entities;
using MegaCity.Models;

namespace MegaCity.Services;

public interface IBuildingsService
{
    public Task<IEnumerable<Building>> FindAll();
    public Task<Building?> FindBuildingById(int id);
    public Task<bool> Update(int buildingId, Building building);
    public Task<Building> Create(Building building);
}