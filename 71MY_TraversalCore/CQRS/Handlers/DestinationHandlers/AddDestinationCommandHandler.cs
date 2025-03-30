using _71MY_TraversalCore.CQRS.Commands.DestinationCommands;
using DataAccessLayer.Concrete;
using EntityLayer.Concrete;

namespace _71MY_TraversalCore.CQRS.Handlers.DestinationHandlers
{
    public class AddDestinationCommandHandler
    {
        private readonly Context _context;

        public AddDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(AddDestinationCommand command)
        {
            _context.Destinations.Add(new Destination
            {
                City = command.City,
                Price = command.Price,
                DayNight = command.DayNight,
                Capacity = command.Capacity,
                Status = true
            });

            _context.SaveChanges();
        }
    }
}
