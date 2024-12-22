using demo_app.Application.Common.Interfaces;
using demo_app.Application.Common.Mappings;
using demo_app.Application.Common.Models;

namespace demo_app.Application.Calculator.Queries;


public record GetCalculationItemsWithPaginationQuery : IRequest<PaginatedList<CalculationItemDto>>, IUserId
{
    public Guid? UserId { get; private set; }
    public int PageNumber { get; init; } = 1;
    public int PageSize { get; init; } = 10;

    void IUserId.SetUserId(Guid id)
    {
        UserId = id;
    }
}

public class GetCalculationItemsWithPaginationQueryHandler : IRequestHandler<GetCalculationItemsWithPaginationQuery, PaginatedList<CalculationItemDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetCalculationItemsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<PaginatedList<CalculationItemDto>> Handle(GetCalculationItemsWithPaginationQuery request, CancellationToken cancellationToken)
    {
        return await _context.CalculationItems
            .Where(x => x.UserId == request.UserId)
            .ProjectTo<CalculationItemDto>(_mapper.ConfigurationProvider)
            .PaginatedListAsync(request.PageNumber, request.PageSize);
    }
}
