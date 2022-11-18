using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetCarsQuery : IRequest<IQueryable<CarEntity>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetCarsQuery,IQueryable<CarEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IQueryable<CarEntity>> Handle(GetCarsQuery query, CancellationToken cancellationToken)
        {
            var entities = _context.Cars.Where(d => true);
            return entities;
        }
    }
}