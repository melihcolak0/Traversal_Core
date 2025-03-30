using _71MY_TraversalCore.CQRS.Results.GuideResults;
using MediatR;
using System.Collections.Generic;

namespace _71MY_TraversalCore.CQRS.Queries.GuideQueries
{
    public class GetAllGuideQuery : IRequest<List<GetAllGuideQueryResult>>
    {

    }
}
