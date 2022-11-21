using System.Security.Claims;
using Companion.Domain.Entities;
using Driver.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Migrations;
using Trip.Domain.Entities;

namespace Trip.App.Commands;

/// <summary>
/// Command
/// </summary>
public class CreateTripCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------

    public DriverEntity Driver { get; set; }
    public CompanionEntity Companion { get; set; }
    public CarEntity Car { get; set; }
    public string AddressFrom { get; set; }
    public string AddressTo { get; set; }
    public DateTime DateTime { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class CreateTripCommandHandler : IRequestHandler<CreateTripCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CreateTripCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(CreateTripCommand command, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var entity = new TripEntity
            {
                Id = default,
                
                Driver = command.Driver,
                Companion = command.Companion,
                Car = command.Car,
                AddressFrom = command.AddressFrom,
                AddressTo = command.AddressTo,
                DateTime = command.DateTime,

                CreatedById = Guid.Parse(userId!),
                CreateDate = DateTime.Now,
                UpdateById = Guid.Parse(userId!),
                UpdateDate = DateTime.Now,
                IsDeleted = false
            };
            
            _context.Trips.Add(entity);
            await _context.SaveChanges();
            return entity.Id;
        }
    }
}