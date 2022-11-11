using Driver.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetDriverByUserIdQuery : IRequest<IEnumerable<DriverEntity>>
{
    public string UserId { get; set; }
    
    public class GetAllProductsQueryHandler : IRequestHandler<GetDriverByUserIdQuery,IEnumerable<DriverEntity>>
    {
        private readonly IApplicationDbContext _context;
        public GetAllProductsQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<DriverEntity>> Handle(GetDriverByUserIdQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Drivers.Where(d => d.UserId == query.UserId);
            return productList;
        }
    }
}