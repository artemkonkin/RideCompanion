using Driver.Domain.Entities;
using MediatR;
using Shared.Migrations;

namespace Driver.App.Queries;

public class GetDriverByIdQuery : IRequest<DriverEntity>
{
    public Guid Id { get; set; }
    
    public class GetDriverByIdQueryHandler : IRequestHandler<GetDriverByIdQuery, DriverEntity>
    {
        private readonly IApplicationDbContext _context;

        public GetDriverByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DriverEntity> Handle(GetDriverByIdQuery query, CancellationToken cancellationToken)
        {
            var entity = _context.Drivers.FirstOrDefault(d => d.Id == query.Id);
            return entity;
        }
    }
}