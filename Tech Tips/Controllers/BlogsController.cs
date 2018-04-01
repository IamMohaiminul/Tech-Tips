using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tech_Tips.Models;

namespace Tech_Tips.Controllers
{
    public class BlogsController : Controller
    {
        // GET: Blogs
        public ActionResult Random()
        {
            var blog = new Blog() {Title = "1st Blog!"};

            return View(blog);
        }
    }
}