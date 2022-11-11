using MediatR;
using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Shared.Migrations;

namespace Product.App.Queries;

public class GetAllProductsQuery : IRequest<IEnumerable<ProductEntity>>
{
    public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery,IEnumerable<ProductEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<ProductEntity>> Handle(GetAllProductsQuery query, CancellationToken cancellationToken)
        {
            var productList = await _context.Products.ToListAsync();
            if (productList == null)
            {
                return null;
            }
            return productList.AsReadOnly();
        }
    }
}