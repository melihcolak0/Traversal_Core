using _71MY_TraversalCore.CQRS.Queries.GuideQueries;
using _71MY_TraversalCore.CQRS.Results.GuideResults;
using DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.CQRS.Handlers.GuideHandlers
{
    public class GetGuideByIdQueryHandler : IRequestHandler<GetGuideByIdQuery, GetGuideByIdQueryResult>
    {
        private readonly Context _context;
        public GetGuideByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetGuideByIdQueryResult> Handle(GetGuideByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.Guides.FindAsync(request.id);
            return new GetGuideByIdQueryResult
            {
                GuideId = values.GuideId,
                Name = values.Name,
                Description = values.Description,
                Image = values.Image
            };
        }
    }
}
