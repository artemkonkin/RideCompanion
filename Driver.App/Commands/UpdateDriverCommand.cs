using System.Security.Claims;
using Driver.Domain.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Migrations;

namespace Driver.App.Commands;

/// <summary>
/// Command
/// </summary>
public class UpdateDriverCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public Guid DriverId { get; set; }
    public DriverDto DriverDto { get; set; }

    /// <summary>
    /// Handler
    /// </summary>
    public class UpdateDriverCommandHandler : IRequestHandler<UpdateDriverCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public UpdateDriverCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<Guid> Handle(UpdateDriverCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Drivers.FirstOrDefault(d => d.Id == command.DriverDto.Id);
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (entity == null) 
                return command.DriverId;
            
            entity.FullName = command.DriverDto.FullName;
            entity.BirthDate = command.DriverDto.BirthDate;
            entity.UpdateById = Guid.Parse(userId!);
            entity.UpdateDate = DateTime.Now;

            _context.Drivers.Update(entity);
            await _context.SaveChanges();
            return entity.Id;

        }
    }
}