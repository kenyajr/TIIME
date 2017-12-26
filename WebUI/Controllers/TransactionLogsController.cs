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
    public class TransactionLogsController : Controller
    {
        private TIIMEEntitiesContext db = new TIIMEEntitiesContext();

        // GET: TransactionLogs
        public ActionResult Index()
        {
            var transactionLogs = db.TransactionLogs.Include(t => t.Category).Include(t => t.DateDimension).Include(t => t.Log);
            return View(transactionLogs.ToList());
        }

        // GET: TransactionLogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionLog transactionLog = db.TransactionLogs.Find(id);
            if (transactionLog == null)
            {
                return HttpNotFound();
            }
            return View(transactionLog);
        }

        // GET: TransactionLogs/Create
        public ActionResult Create()
        {
            ViewBag.categoryID = new SelectList(db.Categories, "categoryId", "categoryName");
            ViewBag.transactionDate = new SelectList(db.DateDimensions, "Date", "DaySuffix");
            ViewBag.logId = new SelectList(db.Logs, "logID", "logName");
            return View();
        }

        // POST: TransactionLogs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "logsId,logId,transactionDate,categoryID,description")] TransactionLog transactionLog)
        {
            if (ModelState.IsValid)
            {
                db.TransactionLogs.Add(transactionLog);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categoryID = new SelectList(db.Categories, "categoryId", "categoryName", transactionLog.categoryID);
            ViewBag.transactionDate = new SelectList(db.DateDimensions, "Date", "DaySuffix", transactionLog.transactionDate);
            ViewBag.logId = new SelectList(db.Logs, "logID", "logName", transactionLog.logId);
            return View(transactionLog);
        }

        // GET: TransactionLogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionLog transactionLog = db.TransactionLogs.Find(id);
            if (transactionLog == null)
            {
                return HttpNotFound();
            }
            ViewBag.categoryID = new SelectList(db.Categories, "categoryId", "categoryName", transactionLog.categoryID);
            ViewBag.transactionDate = new SelectList(db.DateDimensions, "Date", "DaySuffix", transactionLog.transactionDate);
            ViewBag.logId = new SelectList(db.Logs, "logID", "logName", transactionLog.logId);
            return View(transactionLog);
        }

        // POST: TransactionLogs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "logsId,logId,transactionDate,categoryID,description")] TransactionLog transactionLog)
        {
            if (ModelState.IsValid)
            {
                db.Entry(transactionLog).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categoryID = new SelectList(db.Categories, "categoryId", "categoryName", transactionLog.categoryID);
            ViewBag.transactionDate = new SelectList(db.DateDimensions, "Date", "DaySuffix", transactionLog.transactionDate);
            ViewBag.logId = new SelectList(db.Logs, "logID", "logName", transactionLog.logId);
            return View(transactionLog);
        }

        // GET: TransactionLogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransactionLog transactionLog = db.TransactionLogs.Find(id);
            if (transactionLog == null)
            {
                return HttpNotFound();
            }
            return View(transactionLog);
        }

        // POST: TransactionLogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransactionLog transactionLog = db.TransactionLogs.Find(id);
            db.TransactionLogs.Remove(transactionLog);
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
