﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _71MY_TraversalCore.Areas.Member.Controllers
{
    [Area("Member")]    
    public class CommentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
