using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Migrations;

namespace Companion.App.Commands;

/// <summary>
/// Command
/// </summary>
public class DeleteCompanionCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public Guid DriverId { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class DeleteCompanionCommandHandler : IRequestHandler<DeleteCompanionCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public DeleteCompanionCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(DeleteCompanionCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Trips.FirstOrDefault(e => e.Id == command.DriverId);
            
            if (entity != null)
            {
                _context.Trips.Remove(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.DriverId;
        }
    }
}