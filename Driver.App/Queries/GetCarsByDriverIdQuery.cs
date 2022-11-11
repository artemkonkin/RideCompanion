using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetCarsByDriverIdQuery : IRequest<IQueryable<CarEntity>>
{
    public Guid DriverId { get; set; }
    
    public class GetAllProductsQueryHandler : IRequestHandler<GetCarsByDriverIdQuery,IQueryable<CarEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<CarEntity>> Handle(GetCarsByDriverIdQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Cars.Where(d => d.DriverId == query.DriverId);
            return productList;
        }
    }
}