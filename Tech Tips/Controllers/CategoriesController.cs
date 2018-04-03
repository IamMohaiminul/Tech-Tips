using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tech_Tips.Models;

namespace Tech_Tips.Controllers
{
    public class CategoriesController : Controller
    {
        private ApplicationDbContext _context;

        public CategoriesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            //base.Dispose(disposing);
            _context.Dispose();
        }

        // GET: Categories
        public ActionResult Index()
        {
            var categories = _context.Categories.ToList();

            return View(categories);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View("CategoryForm");
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
            var category = _context.Categories.SingleOrDefault(b => b.Id == id);

            if (category == null)
                return HttpNotFound();

            return View("CategoryForm", category);
        }

        // POST: Blogs/Save
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(Category category)
        {
            try
            {
                // TODO: Add insert / edit logic here
                if (category.Id == 0)
                {
                    _context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT Categories ON");
                    _context.Categories.Add(category);
                }
                else
                {
                    var categoryInDb = _context.Categories.Single(model => model.Id == category.Id);
                    //TryUpdateModel(blogInDb);
                    categoryInDb.Name = category.Name;
                }

                _context.SaveChanges();

                return RedirectToAction("Index", "Categories");
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.ToString());
                return View("CategoryForm");
            }
        }
    }
}