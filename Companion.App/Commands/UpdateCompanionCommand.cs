using System.Security.Claims;
using Companion.Domain.Dto;
using Companion.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Http;
using Shared.Migrations;

namespace Companion.App.Commands;

/// <summary>
/// Command
/// </summary>
public class UpdateCompanionCommand : IRequest<Guid>
{
    public UpdateCompanionCommand(CompanionDto dto)
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
    public class UpdateCompanionCommandHandler : IRequestHandler<UpdateCompanionCommand, Guid>
    {
        private readonly IApplicationDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        
        public UpdateCompanionCommandHandler(IApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        
        public async Task<Guid> Handle(UpdateCompanionCommand command, CancellationToken cancellationToken)
        {
            var entity = _context.Companions.FirstOrDefault(e => e.Id == command.Dto.Id);
            var userId = _httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);

            if (entity == null) 
                return command.Dto.Id;
            
            entity.Name = command.Dto.Name;
            entity.BirthDate = command.Dto.BirthDate;
            entity.PhoneNumber = command.Dto.PhoneNumber;
            entity.UpdateById = Guid.Parse(userId!);
            entity.UpdateDate = DateTime.Now;

            _context.Companions.Update(entity);
            await _context.SaveChanges();
            return command.Dto.Id;
        }
    }
}