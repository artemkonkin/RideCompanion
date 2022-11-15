using MediatR;

namespace Driver.App.Queries;

public class GetProductByIdQuery : IRequest<int>
{
    public int Id { get; set; }

    public GetProductByIdQuery(int id)
    {
        Id = id;
    }
}