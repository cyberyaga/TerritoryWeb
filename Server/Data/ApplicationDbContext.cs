using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Duende.IdentityServer.EntityFramework.Options;
using TerritoryWeb.Server.Models;

namespace TerritoryWeb.Server.Data;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>
{
    public ApplicationDbContext(
        DbContextOptions options,
        IOptions<OperationalStoreOptions> operationalStoreOptions) : base(options, operationalStoreOptions)
    {
    }
    public DbSet<Congregation> Congregations { get; set; } = default!;
    public DbSet<Door> Doors { get; set; } = default!;
    public DbSet<DoorCode> DoorCodes { get; set; } = default!;
    public DbSet<Language> Languages { get; set; } = default!;
    public DbSet<PublisherType> PublisherTypes { get; set; } = default!;
    public DbSet<Territory> Territories { get; set; } = default!;
    public DbSet<TerritoryAccess> TerritoryAccess { get; set; } = default!;
    public DbSet<TerritoryBound> TerritoryBounds { get; set; } = default!;
    public DbSet<TerritoryType> TerritoryTypes { get; set; } = default!;
    public DbSet<URLMinimizeStore> URLMinimizeStore { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seed Data
        modelBuilder = DataSeed.modelBuilderSeed(modelBuilder);
        base.OnModelCreating(modelBuilder);
    }
}
