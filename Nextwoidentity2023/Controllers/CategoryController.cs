using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nextwoidentity2023.Data;
using Nextwoidentity2023.Models;
using System.Data;

namespace Nextwoidentity2023.Controllers
{
    public class CategoryController : Controller
    {
        private NextwoDbContext db;
        public CategoryController(NextwoDbContext _db)
        {
            db = _db;
        }
        public IActionResult Categorys()
        {
            return View(db.Categorys);
        }
        [Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult CreateCategory()
        {

            return View();
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                var name = db.Categorys.Where(x => x.Name == category.Name).FirstOrDefault();
                if (name == null)
                {
                    db.Categorys.Add(category);
                    db.SaveChanges();
                    return RedirectToAction("Categorys");

                }
                else
                {
                    ModelState.AddModelError("", "Opps,The category already exists");
                }


            }
            return View(category);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Categorys");
            }
            var data = db.Categorys.Find(id);
            if (data == null)
            {
                return RedirectToAction("Categorys");
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditCategory(Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categorys.Update(category);
                db.SaveChanges();
                return RedirectToAction("Categorys");
            }
            return View(category);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Categorys");
            }
            var data = db.Categorys.Find(id);
            if (data == null)
            {
                return RedirectToAction("Categorys");
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteCategory(Category category)
        {
            var data = db.Categorys.Find(category.CategoryId);
            if (data == null)
            {
                return RedirectToAction("Categorys");
            }
            db.Categorys.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Categorys");
        }
        [HttpGet]

        public IActionResult DetailsCategory(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Categorys");
            }
            var data = db.Categorys.Find(id);
            if (data == null)
            {
                return RedirectToAction("Categorys");
            }
            return View(data);
        }
    }
}
