using MegaCity.DbContexts.Entities;
using Microsoft.EntityFrameworkCore;

namespace MegaCity.DbContexts;

public class BuildingsDbContext : DbContext
{
    public DbSet<BuildingDbo> Buildings { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseInMemoryDatabase("MegaCity");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BuildingDbo>(entity => { entity.Property(e => e.Id).ValueGeneratedOnAdd(); });
        modelBuilder.Entity<BuildingDbo>().HasKey(x => x.Id);

        modelBuilder.Entity<BuildingDbo>().HasData(
            new BuildingDbo { Id = 1, Name = "Big Building", Address = "Highway 420", Index = "NO600", EnergyUnits = 400, EnergyUnitMax = 500, SectorCode = "CX60" },
            new BuildingDbo { Id = 2, Name = "Small Building", Address = "Highway 1200", Index = "NO90000", EnergyUnits = 20, EnergyUnitMax = 100, SectorCode = "CX12" }
        );
    }
}