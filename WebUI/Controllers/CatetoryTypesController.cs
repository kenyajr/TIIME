using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Domain.Concrete;

namespace WebUI.Controllers
{
    public class CatetoryTypesController : Controller
    {
        private TIIMEEntitiesContext db = new TIIMEEntitiesContext();

        // GET: CatetoryTypes
        public ActionResult Index()
        {
            return View(db.CatetoryTypes.ToList());
        }

        // GET: CatetoryTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatetoryType catetoryType = db.CatetoryTypes.Find(id);
            if (catetoryType == null)
            {
                return HttpNotFound();
            }
            return View(catetoryType);
        }

        // GET: CatetoryTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CatetoryTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "categoryTypeID,categoryTypeName,categoryTypeDescription,createdDate")] CatetoryType catetoryType)
        {
            if (ModelState.IsValid)
            {
                db.CatetoryTypes.Add(catetoryType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(catetoryType);
        }

        // GET: CatetoryTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatetoryType catetoryType = db.CatetoryTypes.Find(id);
            if (catetoryType == null)
            {
                return HttpNotFound();
            }
            return View(catetoryType);
        }

        // POST: CatetoryTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "categoryTypeID,categoryTypeName,categoryTypeDescription,createdDate")] CatetoryType catetoryType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(catetoryType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(catetoryType);
        }

        // GET: CatetoryTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CatetoryType catetoryType = db.CatetoryTypes.Find(id);
            if (catetoryType == null)
            {
                return HttpNotFound();
            }
            return View(catetoryType);
        }

        // POST: CatetoryTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CatetoryType catetoryType = db.CatetoryTypes.Find(id);
            db.CatetoryTypes.Remove(catetoryType);
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
