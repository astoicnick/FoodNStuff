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
    public class CustomerController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Create
        //GET: Customer/Create
        public ActionResult Create()
        {
            return View();
        }

        //Create confirm
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult Create(Customer customerToCreate)
        {

            if (ModelState.IsValid)
            {
                _db.Customers.Add(customerToCreate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerToCreate);
        }

        //Read All
        // GET: Customer
        public ActionResult Index()
        {
            return View(_db.Customers.ToList());
        }

        //Read Detailed
        //GET: Customer/{Id}
        public ActionResult DetailedView(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //Update General
        //GET: Customer/Update/{id}
        public ActionResult Update(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }
        //Update Confirm
        //POST: Customer/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public ActionResult Update(Customer customerToUpdate)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(customerToUpdate).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customerToUpdate);
        }

        //Delete General
        //GET: Customer/Delete/{id}
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = _db.Customers.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        //Delete Confirm
        //POST: Customer/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(Customer customerToDelete)
        {
            _db.Customers.Remove(customerToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}