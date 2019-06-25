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
    public class TransactionController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();

        //Create
        //GET: Transaction/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");
            ViewBag.ProductId = new SelectList(_db.Products.ToList(),"ProductId","Name");
            return View();
        }

        //Create confirm
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Create")]
        public ActionResult Create(Transaction transactionToCreate)
        {
            if (ModelState.IsValid)
            {
                _db.Transactions.Add(transactionToCreate);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactionToCreate);
        }

        //Read All
        // GET: Transaction
        public ActionResult Index()
        {
            var transactionList = _db.Transactions.OrderBy(t=>t.Customer.LastName).ThenBy(t=>t.Customer.FirstName).ToList();
            return View(transactionList);
        }

        //Read Detailed
        //GET: Transaction/{Id}
        public ActionResult DetailedView(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //Update General
        //GET: Transaction/Update/{id}
        public ActionResult Update(long? id)
        {
            ViewBag.CustomerId = new SelectList(_db.Customers.ToList(), "CustomerId", "FullName");
            ViewBag.ProductId = new SelectList(_db.Products.ToList(), "ProductId", "Name");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }
        //Update Confirm
        //POST: Transaction/Update/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Update")]
        public ActionResult Update(Transaction transactionToUpdate)
        {
            if (ModelState.IsValid)
            {
                _db.Entry(transactionToUpdate).State = EntityState.Modified;
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(transactionToUpdate);
        }

        //Delete General
        //GET: Transaction/Delete/{id}
        public ActionResult Delete(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Transaction transaction = _db.Transactions.Find(id);
            if (transaction == null)
            {
                return HttpNotFound();
            }
            return View(transaction);
        }

        //Delete Confirm
        //POST: Transaction/Delete/{id}
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public ActionResult Delete(Transaction transactionToDelete)
        {
            _db.Transactions.Remove(transactionToDelete);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}