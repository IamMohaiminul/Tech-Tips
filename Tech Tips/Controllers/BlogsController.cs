using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tech_Tips.Models;
using Tech_Tips.ViewModels;

namespace Tech_Tips.Controllers
{
    public class BlogsController : Controller
    {
        private ApplicationDbContext _context;

        public BlogsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Blogs
        public ActionResult Index(int? pageIndex, string sortBy)
        {
            if (!pageIndex.HasValue)
                pageIndex = 1;
            if (string.IsNullOrWhiteSpace(sortBy))
                sortBy = "Title";

            var blogs = _context.Blogs.Include(b => b.Category).ToList();

            return View(blogs);
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int id)
        {
            var blog = _context.Blogs.Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            if (blog == null)
                return HttpNotFound();

            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();

            var blogFormViewModel = new BlogFormViewModel()
            {
                Categories = categories
            };

            return View("BlogForm", blogFormViewModel);
        }

        // POST: Blogs/Create
        [HttpPost]
        public ActionResult Create(Blog blog)
        {
            try
            {
                // TODO: Add insert logic here
                _context.Blogs.Add(blog);
                _context.SaveChanges();
                return RedirectToAction("Index", "Blogs");
            }
            catch
            {
                return View("BlogForm");
            }
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int id)
        {
            var blog = _context.Blogs.Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            if (blog == null)
                return HttpNotFound();

            var blogFormViewModel = new BlogFormViewModel()
            {
                Categories = _context.Categories.ToList(),
                Blog = blog
            };

            return View("BlogForm", blogFormViewModel);
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

        // GET: Blogs/Publish/{year}/{month}
        [Route("Blogs/Publish/{year:regex(\\d{4})}/{month:regex(\\d{2}):range(1,12)}")]
        public ActionResult ByPublishDate(int year, int month)
        {
            return Content(String.Format("year={0}&month={1}", year, month));
        }
    }
}