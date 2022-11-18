using System.Security.Claims;
using Driver.Domain.Dto;
using Driver.Domain.Entities;
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
    public Guid CarId { get; set; }
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
            var entity = _context.Drivers.FirstOrDefault(e => e.Id == command.CarId);
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (entity != null)
            {
                var newEntity = new DriverEntity
                {
                    Id = entity.Id,
                    UserId = command.DriverDto.UserId,
                    FullName = command.DriverDto.FullName,
                    BirthDate = command.DriverDto.BirthDate,
                    CreatedById = entity.CreatedById,
                    CreateDate = entity.CreateDate,
                    UpdateById = Guid.Parse(userId!),
                    UpdateDate = DateTime.Now,
                    IsDeleted = command.DriverDto.IsDeleted
                };
                
                _context.Drivers.Update(newEntity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.CarId;
        }
    }
}