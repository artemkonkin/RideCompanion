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
    public UpdateTripCommand(TripDto viewModelTripDto)
    {
        TripDto = viewModelTripDto;
    }

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

            if (entity == null) 
                return command.TripDto.Id;
            
            entity.Driver = command.TripDto.Driver;
            entity.Companion = command.TripDto.Companion;
            entity.Car = command.TripDto.Car;
            entity.AddressFrom = command.TripDto.AddressFrom;
            entity.AddressTo = command.TripDto.AddressTo;
            entity.DateTime = command.TripDto.DateTime;
            entity.UpdateById = Guid.Parse(userId!);
            entity.UpdateDate = DateTime.Now;
            entity.IsDeleted = command.TripDto.IsDeleted;

            _context.Trips.Update(entity);
            await _context.SaveChanges();
            return entity.Id;

        }
    }
}