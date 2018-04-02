using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tech_Tips.Models;
using Tech_Tips.ViewModels;

namespace Tech_Tips.Controllers
{
    public class BlogsController : Controller
    {
        private static IEnumerable<Blog> GetBlogs()
        {
            return new List<Blog>()
            {
                new Blog() {Id = 1, Title = "1st Blog!"},
                new Blog() {Id = 2, Title = "2nd Blog!"}
            };
        }

        // GET: Blogs
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Title";

            var blogs = GetBlogs();

            return View(blogs);
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int id)
        {
            var blog = GetBlogs().SingleOrDefault(c => c.Id == id);

            if (blog == null)
                return HttpNotFound();

            return View(blog);
        }

        // GET: Blogs/Random
        public ActionResult Random()
        {
            var blog = new Blog() { Title = "1st Blog!" };
            var articles = new List<Article>()
            {
                new Article() {Title = "1st Article!"},
                new Article() {Title = "2nd Article!"}
            };

            var randomBlogViewModel = new RandomBlogViewModel()
            {
                Blog = blog,
                Articles = articles
            };

            return View(randomBlogViewModel);
        }

        // GET: Blogs/Edit/{id}
        public ActionResult Edit(int id)
        {
            return Content("id=" + id);
        }

        // GET: Blogs/Publish/{year}/{month}
        [Route("Blogs/Publish/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByPublishDate(int year, int month)
        {
            return Content(String.Format("year={0}&month={1}", year, month));
        }
    }
}