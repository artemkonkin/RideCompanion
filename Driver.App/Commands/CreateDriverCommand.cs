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
public class CreateDriverCommand : IRequest<Guid>
{
    // ----------------------------
    // Props
    // ----------------------------
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class CreateDriverCommandHandler : IRequestHandler<CreateDriverCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CreateDriverCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(CreateDriverCommand command, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var entity = new DriverEntity
            {
                Id = default,
                
                UserId = userId,
                FullName = command.FullName,
                BirthDate = command.BirthDate,

                CreatedById = Guid.Parse(userId!),
                CreateDate = DateTime.Now,
                UpdateById = Guid.Parse(userId!),
                UpdateDate = DateTime.Now,
                IsDeleted = false
            };
            
            _context.Drivers.Add(entity);
            await _context.SaveChanges();
            return entity.Id;
        }
    }
}