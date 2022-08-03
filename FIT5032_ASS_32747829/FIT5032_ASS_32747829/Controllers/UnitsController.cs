using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_ASS_32747829.Models;

namespace FIT5032_ASS_32747829.Controllers
{
    public class UnitsController : Controller
    {
        private Model_booking db = new Model_booking();

        // GET: Units
        public ActionResult Index()
        {
            var units = db.Units.Include(u => u.Booking);
            return View(units.ToList());
        }

        // GET: Units/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Units units = db.Units.Find(id);
            if (units == null)
            {
                return HttpNotFound();
            }
            return View(units);
        }

        // GET: Units/Create
        public ActionResult Create()
        {
            ViewBag.UsersID = new SelectList(db.Booking, "Id", "FirstName");
            return View();
        }

        // POST: Units/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,UsersID")] Units units)
        {
            if (ModelState.IsValid)
            {
                db.Units.Add(units);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UsersID = new SelectList(db.Booking, "Id", "FirstName", units.UsersID);
            return View(units);
        }

        // GET: Units/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Units units = db.Units.Find(id);
            if (units == null)
            {
                return HttpNotFound();
            }
            ViewBag.UsersID = new SelectList(db.Booking, "Id", "FirstName", units.UsersID);
            return View(units);
        }

        // POST: Units/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,UsersID")] Units units)
        {
            if (ModelState.IsValid)
            {
                db.Entry(units).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UsersID = new SelectList(db.Booking, "Id", "FirstName", units.UsersID);
            return View(units);
        }

        // GET: Units/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Units units = db.Units.Find(id);
            if (units == null)
            {
                return HttpNotFound();
            }
            return View(units);
        }

        // POST: Units/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Units units = db.Units.Find(id);
            db.Units.Remove(units);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
