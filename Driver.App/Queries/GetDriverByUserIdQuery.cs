using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetDriverByUserIdQuery : IRequest<IQueryable<DriverEntity>>
{
    public string UserId { get; set; }

    public class GetDriverByUserIdQueryHandler : IRequestHandler<GetDriverByUserIdQuery, IQueryable<DriverEntity>>
    {
        private readonly IApplicationDbContext _context;

        public GetDriverByUserIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IQueryable<DriverEntity>> Handle(GetDriverByUserIdQuery query, CancellationToken cancellationToken)
        {
            var productList = _context.Drivers.Where(d => d.UserId == query.UserId);
            return productList;
        }
    }
}