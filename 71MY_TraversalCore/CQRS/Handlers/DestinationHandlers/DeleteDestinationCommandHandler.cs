using _71MY_TraversalCore.CQRS.Commands.DestinationCommands;
using DataAccessLayer.Concrete;

namespace _71MY_TraversalCore.CQRS.Handlers.DestinationHandlers
{
    public class DeleteDestinationCommandHandler
    {
        private readonly Context _context;

        public DeleteDestinationCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(DeleteDestinationCommand command)
        {
            var value = _context.Destinations.Find(command.id);
            _context.Destinations.Remove(value);
            _context.SaveChanges();
        }
    }
}
