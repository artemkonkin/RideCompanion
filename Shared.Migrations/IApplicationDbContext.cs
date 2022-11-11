using Driver.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;

namespace Shared.Migrations;

public interface IApplicationDbContext
{
    DbSet<ProductEntity> Products { get; set; }
    
    DbSet<DriverEntity> Drivers { get; set; }
    DbSet<CarEntity> Cars { get; set; }
    
    Task<int> SaveChanges();
}