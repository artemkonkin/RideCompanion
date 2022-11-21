using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetDriversQuery : IRequest<IQueryable<DriverEntity>>
{
    public class GetDriversQueryHandler : IRequestHandler<GetDriversQuery, IQueryable<DriverEntity>>
    {
        private readonly IApplicationDbContext _context;

        public GetDriversQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<DriverEntity>> Handle(GetDriversQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Drivers.Where(d => true);
            return productList;
        }
    }
}