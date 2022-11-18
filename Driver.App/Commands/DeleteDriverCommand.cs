using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Migrations;

namespace Driver.App.Commands;

/// <summary>
/// Command
/// </summary>
public class DeleteDriverCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public Guid DriverId { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class DeleteDriverCommandHandler : IRequestHandler<DeleteDriverCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public DeleteDriverCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(DeleteDriverCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Drivers.FirstOrDefault(e => e.Id == command.DriverId);
            
            if (entity != null)
            {
                _context.Drivers.Remove(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.DriverId;
        }
    }
}