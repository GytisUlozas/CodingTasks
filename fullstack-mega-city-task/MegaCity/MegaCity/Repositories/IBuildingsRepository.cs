using MegaCity.DbContexts.Entities;

namespace MegaCity.Repositories;

public interface IBuildingsRepository
{
    Task<bool> SaveChangesAsync();
    Task<IEnumerable<BuildingDbo>> FindAll();
    Task<BuildingDbo> Create(BuildingDbo building);
}