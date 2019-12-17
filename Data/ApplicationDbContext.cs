using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TerritoryWeb.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options){}
        
        //Database Tables
        public DbSet<Congregation> Congregations { get; set; }
        public DbSet<Door> Doors { get; set; }
        public DbSet<DoorCode> DoorCodes { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PublisherType> PublisherTypes { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<TerritoryAccess> TerritoryAccesses { get; set; }
        public DbSet<TerritoryBound> TerritoryBounds { get; set; }
        public DbSet<TerritoryType> TerritoryTypes { get; set; }
        public DbSet<URLMinimizeStore> URLMinimizeStores { get; set; }
    }
}
