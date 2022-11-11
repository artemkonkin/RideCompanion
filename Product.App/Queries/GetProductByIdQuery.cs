using MediatR;
using Product.Domain.Entities;
using Shared.Migrations;

namespace Product.App.Queries;

public class GetProductByIdQuery : IRequest<ProductEntity>
{
    public int Id { get; set; }

    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductEntity>
    {
        private readonly IApplicationDbContext _context;

        public GetProductByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ProductEntity> Handle(GetProductByIdQuery query, CancellationToken cancellationToken)
        {
            var product = _context.Products.Where(a => a.Id == query.Id).FirstOrDefault();
            if (product == null) return null;
            return product;
        }
    }
}