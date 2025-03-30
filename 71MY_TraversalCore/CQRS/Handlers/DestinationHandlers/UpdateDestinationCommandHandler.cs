using _71MY_TraversalCore.CQRS.Commands.DestinationCommands;
using DataAccessLayer.Concrete;

namespace _71MY_TraversalCore.CQRS.Handlers.DestinationHandlers
{
    public class UpdateDestinationCommandHandler
    {
        private readonly Context _context;

        public UpdateDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(UpdateDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.DestinationId);
            value.City = command.City;
            value.DayNight = command.DayNight;
            value.Price = command.Price;
            value.Status = true;
            _context.SaveChanges();
        }
    }
}
