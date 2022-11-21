using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Companion.App.Queries;

public class GetCompanionsByUserIdQuery : IRequest<IQueryable<CarEntity>>
{
    public Guid DriverId { get; set; }
    
    public class GetCompanionsByUserIdQueryHandler : IRequestHandler<GetCompanionsByUserIdQuery,IQueryable<CarEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetCompanionsByUserIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<CarEntity>> Handle(GetCompanionsByUserIdQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Cars.Where(d => d.DriverId == query.DriverId);
            return productList;
        }
    }
}