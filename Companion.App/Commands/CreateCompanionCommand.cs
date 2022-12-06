using System.Security.Claims;
using Companion.Domain.Dto;
using Companion.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Shared.Migrations;

namespace Companion.App.Commands;

/// <summary>
/// Command
/// </summary>
public class CreateCompanionCommand : IRequest<Guid>
{
    public CreateCompanionCommand(CompanionDto dto)
    {
        Dto = dto;
    }

    // ----------------------------
    // Props
    // ----------------------------
    public CompanionDto Dto { get; set; }
    
    /// <summary>
    /// Handler
    /// </summary>
    public class CreateCompanionCommandHandler : IRequestHandler<CreateCompanionCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public CreateCompanionCommandHandler(IApplicationDbContext context, UserManager<IdentityUser> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _userManager = userManager;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(CreateCompanionCommand command, CancellationToken cancellationToken)
        {
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
            
            var entity = new CompanionEntity
            {
                Id = default,
                
                Name = command.Dto.Name,
                BirthDate = command.Dto.BirthDate,
                PhoneNumber = command.Dto.PhoneNumber,

                CreatedById = Guid.Parse(userId!),
                CreateDate = DateTime.Now,
                UpdateById = Guid.Parse(userId!),
                UpdateDate = DateTime.Now,
                IsDeleted = false
            };
            
            _context.Companions.Add(entity);
            await _context.SaveChanges();
            return entity.Id;
        }
    }
}