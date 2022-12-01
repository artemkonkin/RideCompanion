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
            
            var newEntity = new CompanionEntity
            {
                Id = entity.Id,

                Name = command.Dto.Name,
                BirthDate = command.Dto.BirthDate,
                PhoneNumber = command.Dto.PhoneNumber,

                CreatedById = entity.CreatedById,
                CreateDate = entity.CreateDate,
                UpdateById = Guid.Parse(userId!),
                UpdateDate = DateTime.Now,
                IsDeleted = command.Dto.IsDeleted
            };
                
            _context.Companions.Update(newEntity);
            
            await _context.SaveChanges();
            
            return entity.Id;
        }
    }
}