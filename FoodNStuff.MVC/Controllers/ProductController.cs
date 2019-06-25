using FoodNStuff.MVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace FoodNStuff.MVC.Controllers
{
    public class ProductController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Create
        //GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        //Create confirm
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult Create(Product productToCreate)
        {

            if (ModelState.IsValid)
            {
                _db.Products.Add(productToCreate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productToCreate);
        }

        //Read All
        // GET: Product
        public ActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        //Read Detailed
        //GET: Product/{Id}
        public ActionResult DetailedView(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //Update General
        //GET: Product/Update/{id}
        public ActionResult Update(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }
        //Update Confirm
        //POST: Product/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public ActionResult Update(Product productToUpdate)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(productToUpdate).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(productToUpdate);
        }

        //Delete General
        //GET: Product/Delete/{id}
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = _db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //Delete Confirm
        //POST: Product/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(Product productToDelete)
        {
            _db.Products.Remove(productToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}