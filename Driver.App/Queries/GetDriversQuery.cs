using Driver.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetDriversQuery : IRequest<IEnumerable<DriverEntity>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetDriversQuery,IEnumerable<DriverEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DriverEntity>> Handle(GetDriversQuery query, CancellationToken cancellationToken)
        {
            var productList = await _context.Drivers.ToListAsync(cancellationToken: cancellationToken);
            return productList.AsReadOnly();
        }
    }
}