using Microsoft.EntityFrameworkCore;
using TerritoryWeb.Data.Models;
using Pomelo.EntityFrameworkCore.MySql;

namespace TerritoryWeb.Data.Database;
public class TerritoryWebDbContext : DbContext
{
    public TerritoryWebDbContext(DbContextOptions<TerritoryWebDbContext> options) : base(options)
    {
    }

    public DbSet<Congregation> Congregations => Set<Congregation>();
    public DbSet<Door> Doors => Set<Door>();
    public DbSet<DoorCode> DoorCodes => Set<DoorCode>();
    public DbSet<Language> Languages => Set<Language>();
    public DbSet<PublisherType> PublisherTypes => Set<PublisherType>();
    public DbSet<Territory> Territories => Set<Territory>();
    public DbSet<TerritoryAccess> TerritoryAccess => Set<TerritoryAccess>();
    public DbSet<TerritoryBound> TerritoryBounds => Set<TerritoryBound>();
    public DbSet<TerritoryType> TerritoryTypes => Set<TerritoryType>();
    public DbSet<URLMinimizeStore> URLMinimizeStore => Set<URLMinimizeStore>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        //Seed Data
        modelBuilder = DataSeed.modelBuilderSeed(modelBuilder);
    }
}