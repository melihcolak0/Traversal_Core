using MediatR;

namespace _71MY_TraversalCore.CQRS.Commands.GuideCommands
{
    public class AddGuideCommand : IRequest
    {       
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
    }
}
