using _71MY_TraversalCore.CQRS.Commands.DestinationCommands;
using _71MY_TraversalCore.CQRS.Handlers.DestinationHandlers;
using _71MY_TraversalCore.CQRS.Queries.DestinationQueries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/DestinationCQRS")]
    public class DestinationCQRSController : Controller
    {
        private readonly GetAllDestinationQueryHandler _getAllDestinationQueryHandler;
        private readonly GetDestinationByIdQueryHandler _getDestinationByIdQueryHandler;
        private readonly AddDestinationCommandHandler _addDestinationCommandHandler;
        private readonly DeleteDestinationCommandHandler _deleteDestinationCommandHandler;
        private readonly UpdateDestinationCommandHandler _updateDestinationCommandHandler;

        public DestinationCQRSController(GetAllDestinationQueryHandler getAllDestinationQueryHandler, GetDestinationByIdQueryHandler getDestinationByIdQueryHandler, AddDestinationCommandHandler addDestinationCommandHandler, DeleteDestinationCommandHandler deleteDestinationCommandHandler, UpdateDestinationCommandHandler updateDestinationCommandHandler)
        {
            _getAllDestinationQueryHandler = getAllDestinationQueryHandler;
            _getDestinationByIdQueryHandler = getDestinationByIdQueryHandler;
            _addDestinationCommandHandler = addDestinationCommandHandler;
            _deleteDestinationCommandHandler = deleteDestinationCommandHandler;
            _updateDestinationCommandHandler = updateDestinationCommandHandler;
        }

        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            var values = _getAllDestinationQueryHandler.Handle();
            return View(values);
        }

        [Route("GetDestinationById/{id}")]
        [HttpGet]
        public IActionResult GetDestinationById(int id)
        {
            var values = _getDestinationByIdQueryHandler.Handle(new GetDestinationByIdQuery(id));
            return View(values);
        }

        [Route("GetDestinationById/{id}")]
        [HttpPost]
        public IActionResult GetDestinationById(UpdateDestinationCommand command)
        {
            _updateDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [Route("AddDestination")]
        [HttpGet]
        public IActionResult AddDestination()
        {
            return View();
        }

        [Route("AddDestination")]
        [HttpPost]
        public IActionResult AddDestination(AddDestinationCommand command)
        {
            _addDestinationCommandHandler.Handle(command);
            return RedirectToAction("Index");
        }

        [Route("DeleteDestination/{id}")]
        public IActionResult DeleteDestination(int id)
        {
            _deleteDestinationCommandHandler.Handle(new DeleteDestinationCommand(id));
            return RedirectToAction("Index");
        }
    }
}
