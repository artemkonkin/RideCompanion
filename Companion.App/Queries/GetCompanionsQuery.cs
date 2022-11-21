using MediatR;
using Shared.Migrations;
using Trip.Domain.Entities;

namespace Companion.App.Queries;

public class GetCompanionsQuery : IRequest<IQueryable<TripEntity>>
{
    public class GetCompanionsQueryHandler : IRequestHandler<GetCompanionsQuery,IQueryable<TripEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetCompanionsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<TripEntity>> Handle(GetCompanionsQuery query, CancellationToken cancellationToken)
        {
            var entities = _context.Trips.Where(d => true);
            return entities;
        }
    }
}