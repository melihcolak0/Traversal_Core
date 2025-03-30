using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _71MY_TraversalCore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        public IActionResult Index()
        {
            var values = _commentService.TGetCommentListWithDest();
            return View(values);
        }

        public IActionResult DeleteComment(int id)
        {
            var value = _commentService.TGetById(id);
            _commentService.TDelete(value);
            return RedirectToAction("Index");
        }
    }
}
