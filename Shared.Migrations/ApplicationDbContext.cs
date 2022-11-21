using Companion.Domain.Entities;
using Driver.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trip.Domain.Entities;

namespace Shared.Migrations;

public class ApplicationDbContext : IdentityDbContext, IApplicationDbContext
{
    public DbSet<DriverEntity> Drivers { get; set; }
    public DbSet<CarEntity> Cars { get; set; }
    public DbSet<TripEntity> Trips { get; set; }
    public DbSet<CompanionEntity> Companions { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public async Task<int> SaveChanges()
    {
        return await base.SaveChangesAsync();
    }
}