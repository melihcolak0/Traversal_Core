using _71MY_TraversalCore.CQRS.Results.GuideResults;
using MediatR;

namespace _71MY_TraversalCore.CQRS.Queries.GuideQueries
{
    public class GetGuideByIdQuery : IRequest<GetGuideByIdQueryResult>
    {
        public GetGuideByIdQuery(int id)
        {
            this.id = id;
        }

        public int id { get; set; }
    }
}
