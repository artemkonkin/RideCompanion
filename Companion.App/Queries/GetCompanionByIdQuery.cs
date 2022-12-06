using MediatR;
using Shared.Migrations;
using Companion.Domain.Entities;

namespace Companion.App.Queries;

public class GetCompanionByIdQuery : IRequest<CompanionEntity>
{
    public GetCompanionByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
    
    public class GetCompanionByIdQueryHandler : IRequestHandler<GetCompanionByIdQuery,CompanionEntity>
    {
        private readonly IApplicationDbContext _context;
        public GetCompanionByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<CompanionEntity> Handle(GetCompanionByIdQuery query, CancellationToken cancellationToken)
        {
            var data = _context.Companions.FirstOrDefault(d => d.Id == query.Id);
            return data;
        }
    }
}