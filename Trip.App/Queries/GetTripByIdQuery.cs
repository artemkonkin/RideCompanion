using MediatR;
using Shared.Migrations;
using Trip.Domain.Entities;

namespace Trip.App.Queries;

public class GetTripByIdQuery : IRequest<TripEntity>
{
    public GetTripByIdQuery()
    {
    }

    public GetTripByIdQuery(Guid id)
    {
        Id = id;
    }

    public Guid Id { get; set; }
    
    public class GetTripByIdQueryHandler : IRequestHandler<GetTripByIdQuery,TripEntity>
    {
        private readonly IApplicationDbContext _context;
        public GetTripByIdQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<TripEntity> Handle(GetTripByIdQuery query, CancellationToken cancellationToken)
        {
            var data = _context.Trips.FirstOrDefault(d => d.Id == query.Id);
            return data;
        }
    }
}