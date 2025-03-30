using _71MY_TraversalCore.CQRS.Queries.DestinationQueries;
using _71MY_TraversalCore.CQRS.Results.DestinationResults;
using DataAccessLayer.Concrete;

namespace _71MY_TraversalCore.CQRS.Handlers.DestinationHandlers
{
    public class GetDestinationByIdQueryHandler
    {
        private readonly Context _context;

        public GetDestinationByIdQueryHandler(Context context)
        {
            _context = context;
        }

        public GetDestinationByIdQueryResult Handle(GetDestinationByIdQuery query)
        {
            var values = _context.Destinations.Find(query.id);

            return new GetDestinationByIdQueryResult
            {
                DestinationId = values.DestinationId,
                City = values.City,
                DayNight = values.DayNight,
                Price = values.Price
            };
        }
            
    }
}
