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
public class UpdateCarCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public Guid CarId { get; set; }
    public CarDto CarDto { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class UpdateCarCommandHandler : IRequestHandler<UpdateCarCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UpdateCarCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(UpdateCarCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Cars.FirstOrDefault(e => e.Id == command.CarId);
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            if (entity != null)
            {
                var newEntity = new CarEntity
                {
                    Id = entity.Id,
                    UserId = entity.UserId,
                    DriverId = entity.DriverId,
                    Number = command.CarDto.Number,
                    Color = command.CarDto.Color,
                    Model = command.CarDto.Model,
                    CreatedById = entity.CreatedById,
                    CreateDate = entity.CreateDate,
                    UpdateById = Guid.Parse(userId!),
                    UpdateDate = DateTime.Now,
                    IsDeleted = command.CarDto.IsDeleted
                };
                
                _context.Cars.Update(newEntity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.CarId;
        }
    }
}