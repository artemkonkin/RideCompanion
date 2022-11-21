using Companion.Domain.Entities;
using Driver.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Trip.Domain.Entities;

namespace Shared.Migrations;

public interface IApplicationDbContext
{
    DbSet<DriverEntity> Drivers { get; set; }
    DbSet<CarEntity> Cars { get; set; }
    DbSet<TripEntity> Trips { get; set; }
    DbSet<CompanionEntity> Companions { get; set; }
    
    Task<int> SaveChanges();
}