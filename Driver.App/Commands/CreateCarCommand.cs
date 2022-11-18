using System.Security.Claims;
using Driver.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Migrations;

namespace Driver.App.Commands;

/// <summary>
/// Command
/// </summary>
public class CreateCarCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public Guid DriverId { get; set; }
    public string Number { get; set; }
    public string Color { get; set; }
    public string Model { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class CreateCarCommandHandler : IRequestHandler<CreateCarCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CreateCarCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(CreateCarCommand command, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var entity = new CarEntity
            {
                Id = default,
                
                UserId = userId,
                DriverId = command.DriverId,
                Number = command.Number,
                Color = command.Color,
                Model = command.Model,

                CreatedById = Guid.Parse(userId!),
                CreateDate = DateTime.Now,
                UpdateById = Guid.Parse(userId!),
                UpdateDate = DateTime.Now,
                IsDeleted = false
            };
            
            _context.Cars.Add(entity);
            await _context.SaveChanges();
            return entity.Id;
        }
    }
}