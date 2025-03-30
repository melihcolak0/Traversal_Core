using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace _71MY_TraversalCore.Controllers
{
    public class CommentController : Controller
    {
        CommentManager commentManager = new CommentManager(new EfCommentDal());     

        [HttpGet]
        public PartialViewResult AddComment()
        {            
            return PartialView();
        }

        [HttpPost]
        public IActionResult AddComment(Comment comment)
        {            
            comment.CommentDate = DateTime.Now;
            comment.CommentStatus = true;
            commentManager.TAdd(comment);
            return RedirectToAction("Index", "Destination");
        }
    }
}
