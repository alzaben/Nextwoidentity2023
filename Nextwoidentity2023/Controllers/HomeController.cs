using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Nextwoidentity2023.Data;
using Nextwoidentity2023.Models;
using System.Diagnostics;

namespace Nextwoidentity2023.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        
        private NextwoDbContext db;

        public HomeController( NextwoDbContext _db  )
        {
            
            db = _db;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult Privacy()
        {
            return View();
        }
        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Products()
        {
            
            return View(db.Products.Include(x => x.Category));
           
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(product);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public IActionResult EditProduct(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Products");
            }
            var data = db.Products.Find(id);
            if (data == null)
            {
                return RedirectToAction("Products");
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult EditProduct(Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Update(product);
                db.SaveChanges();
                return RedirectToAction("Products");
            }
            return View(product);
        }
        [HttpGet]
        [Authorize(Roles = "Admin")]

        public IActionResult DeleteProduct(int?id)
        {
            if (id == null)
            {
                return RedirectToAction("Products");
            }
            var data = db.Products.Find(id);
            if (data == null)
            {
                return RedirectToAction("Products");
            }
            return View(data);
        }
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public IActionResult DeleteProduct(Product product)
        {
            var data = db.Products.Find(product.ProductId);
            if (data == null)
            {
                return RedirectToAction("Products");
            }
            db.Products.Remove(data);
            db.SaveChanges();
            return RedirectToAction("Products");
        }
        [HttpGet]
        [AllowAnonymous]
        public IActionResult DetailsProduct(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Products");
            }
            var data = db.Products.Find(id);
            if (data == null)
            {
                return RedirectToAction("Products");
            }
            return View(data);
        }

    }
}