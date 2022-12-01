using Companion.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Companion.App.Queries;

public class GetCompanionsQuery : IRequest<IQueryable<CompanionEntity>>
{
    public class GetCompanionsQueryHandler : IRequestHandler<GetCompanionsQuery,IQueryable<CompanionEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetCompanionsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<CompanionEntity>> Handle(GetCompanionsQuery query, CancellationToken cancellationToken)
        {
            var entities = _context.Companions.Where(d => true);
            return entities;
        }
    }
}