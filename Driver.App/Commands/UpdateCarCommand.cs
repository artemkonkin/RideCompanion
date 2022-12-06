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
                entity.Number = command.CarDto.Number;
                entity.Color = command.CarDto.Color;
                entity.Model = command.CarDto.Model;
                entity.UpdateById = Guid.Parse(userId!);
                entity.UpdateDate = DateTime.Now;
                entity.IsDeleted = command.CarDto.IsDeleted;

                _context.Cars.Update(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.CarId;
        }
    }
}