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
public class DeleteCarCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public Guid CarId { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public DeleteCarCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(DeleteCarCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Cars.FirstOrDefault(e => e.Id == command.CarId);
            
            if (entity != null)
            {
                _context.Cars.Remove(entity);
                await _context.SaveChanges();
                return entity.Id;
            }

            return command.CarId;
        }
    }
}