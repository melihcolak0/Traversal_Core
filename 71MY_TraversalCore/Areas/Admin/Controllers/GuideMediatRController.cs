using _71MY_TraversalCore.CQRS.Commands.GuideCommands;
using _71MY_TraversalCore.CQRS.Queries.GuideQueries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    [Route("Admin/GuideMediatR")]
    public class GuideMediatRController : Controller
    {
        private readonly IMediator _mediator;

        public GuideMediatRController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Route("")]
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var values = await _mediator.Send(new GetAllGuideQuery());
            return View(values);
        }

        [Route("UpdateGuide/{id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateGuide(int id)
        {
            var value = await _mediator.Send(new GetGuideByIdQuery(id));
            return View(value);
        }

        [Route("AddGuide")]
        [HttpGet]
        public IActionResult AddGuide()
        {
            return View();
        }

        [Route("AddGuide")]
        [HttpPost]
        public async Task<IActionResult> AddGuide(AddGuideCommand command)
        {
            await _mediator.Send(command);
            return RedirectToAction("Index");
        }
    }
}
