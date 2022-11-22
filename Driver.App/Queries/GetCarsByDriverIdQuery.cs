using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetCarsByDriverIdQuery : IRequest<List<CarEntity>>
{
    public Guid DriverId { get; set; }
    
    public class GetCarsByDriverIdQueryHandler : IRequestHandler<GetCarsByDriverIdQuery,List<CarEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetCarsByDriverIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<List<CarEntity>> Handle(GetCarsByDriverIdQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Cars.Where(d => d.DriverId == query.DriverId);
            return productList.ToList();
        }
    }
}