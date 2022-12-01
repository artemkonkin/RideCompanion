using Companion.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Companion.App.Queries;

public class GetCompanionsByUserIdQuery : IRequest<IQueryable<CompanionEntity>>
{
    public Guid Id { get; set; }
    
    public class GetCompanionsByUserIdQueryHandler : IRequestHandler<GetCompanionsByUserIdQuery,IQueryable<CompanionEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetCompanionsByUserIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<CompanionEntity>> Handle(GetCompanionsByUserIdQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Companions.Where(d => d.Id == query.Id);
            return productList;
        }
    }
}