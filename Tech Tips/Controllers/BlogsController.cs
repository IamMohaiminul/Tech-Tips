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
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (String.IsNullOrWhiteSpace(sortBy))
                sortBy = "Title";

            return Content(String.Format("pageIndex={0}&sortBy={1}", pageIndex, sortBy));
        }

        // GET: Blogs/Random
        public ActionResult Random()
        {
            var blog = new Blog() {Title = "1st Blog!"};

            return View(blog);
        }

        // GET: Blogs/Edit/{id}
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }
    }
}