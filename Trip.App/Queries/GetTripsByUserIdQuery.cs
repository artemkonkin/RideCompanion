using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Trip.App.Queries;

public class GetTripsByUserIdQuery : IRequest<IQueryable<CarEntity>>
{
    public Guid DriverId { get; set; }
    
    public class GetTripsByUserIdQueryHandler : IRequestHandler<GetTripsByUserIdQuery,IQueryable<CarEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetTripsByUserIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<CarEntity>> Handle(GetTripsByUserIdQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Cars.Where(d => d.DriverId == query.DriverId);
            return productList;
        }
    }
}