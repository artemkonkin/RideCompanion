using Driver.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetCarsQuery : IRequest<IEnumerable<CarEntity>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetCarsQuery,IEnumerable<CarEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<CarEntity>> Handle(GetCarsQuery query, CancellationToken cancellationToken)
        {
            var productList = await _context.Cars.ToListAsync(cancellationToken: cancellationToken);
            return productList.AsReadOnly();
        }
    }
}