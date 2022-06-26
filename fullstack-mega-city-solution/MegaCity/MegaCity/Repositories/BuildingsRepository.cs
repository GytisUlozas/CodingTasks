using MegaCity.DbContexts;
using MegaCity.DbContexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaCity.Repositories;

public class BuildingsRepository : IBuildingsRepository, IDisposable
{
    private readonly BuildingsDbContext _context;

    public BuildingsRepository(BuildingsDbContext context)
    {
        _context = context;
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() >=0;
    }

    public async Task<IEnumerable<BuildingDbo>> FindAll()
    {
        return await _context.Buildings.ToListAsync();
    }

    public async Task<BuildingDbo> Create(BuildingDbo building)
    {
        var result = _context.Buildings.Add(building).Entity;
        await SaveChangesAsync();
        return result;
    }
}