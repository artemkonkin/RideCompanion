using System.Security.Claims;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Migrations;
using Trip.Domain.Dto;
using Trip.Domain.Entities;

namespace Trip.App.Commands;

/// <summary>
/// Command
/// </summary>
public class UpdateTripCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public TripDto TripDto { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class UpdateTripCommandHandler : IRequestHandler<UpdateTripCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UpdateTripCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(UpdateTripCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Trips.FirstOrDefault(e => e.Id == command.TripDto.Id);
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (entity != null)
            {
                var newEntity = new TripEntity
                {
                    Id = entity.Id,

                    Driver = command.TripDto.Driver,
                    Companion = command.TripDto.Companion,
                    Car = command.TripDto.Car,
                    AddressFrom = command.TripDto.AddressFrom,
                    AddressTo = command.TripDto.AddressTo,
                    DateTime = command.TripDto.DateTime,

                    CreatedById = entity.CreatedById,
                    CreateDate = entity.CreateDate,
                    UpdateById = Guid.Parse(userId!),
                    UpdateDate = DateTime.Now,
                    IsDeleted = command.TripDto.IsDeleted
                };
                
                _context.Trips.Update(newEntity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.TripDto.Id;
        }
    }
}