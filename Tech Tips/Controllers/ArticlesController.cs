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
    public class ArticlesController : Controller
    {
        private ApplicationDbContext _context;

        public ArticlesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Articles
        public ActionResult Index()
        {
            var articles = _context.Articles.Include(c => c.Category).ToList();
            return View(articles);
        }

        // GET: Articles/Create
        public ActionResult Create()
        {
            var categories = _context.Categories.ToList();

            var articleFormViewModel = new ArticleFormViewModel()
            {
                Categories = categories
            };

            return View("ArticleForm", articleFormViewModel);
        }

        // GET: Articles/Edit/5
        public ActionResult Edit(int id)
        {
            var article = _context.Articles.Include(b => b.Category).SingleOrDefault(b => b.Id == id);

            if (article == null)
                return HttpNotFound();

            var articleFormViewModel = new ArticleFormViewModel()
            {
                Categories = _context.Categories.ToList(),
                Article = article
            };

            return View("ArticleForm", articleFormViewModel);
        }

        // POST: Articles/Save
        [HttpPost]
        public ActionResult Save(Article article)
        {
            try
            {
                // TODO: Add insert / edit logic here
                if (article.Id == 0)
                {
                    _context.Articles.Add(article);
                }
                else
                {
                    var articleInDb = _context.Articles.Single(model => model.Id == article.Id);
                    //TryUpdateModel(blogInDb);
                    articleInDb.Title = article.Title;
                    articleInDb.Description = article.Description;
                    articleInDb.CategoryId = article.CategoryId;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Articles");
            }
            catch
            {
                return View("ArticleForm");
            }
        }
    }
}
