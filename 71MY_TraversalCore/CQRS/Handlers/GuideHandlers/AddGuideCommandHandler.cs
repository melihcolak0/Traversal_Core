using _71MY_TraversalCore.CQRS.Commands.GuideCommands;
using DataAccessLayer.Concrete;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.CQRS.Handlers.GuideHandlers
{
    public class AddGuideCommandHandler : IRequestHandler<AddGuideCommand>
    {
        private readonly Context _context;

        public AddGuideCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(AddGuideCommand request, CancellationToken cancellationToken)
        {
            _context.Guides.Add(new EntityLayer.Concrete.Guide
            {
                Name = request.Name,
                Description = request.Description,
                Image = request.Image,
                Status = true
            });

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
