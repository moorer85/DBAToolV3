using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DBAToolV3.Data.Models;
using DBAToolV3.Models;

namespace DBAToolV3.Controllers
{
    public class ServerDatabases2Controller : Controller
    {
        private DBAToolV3Context db = new DBAToolV3Context();

        // GET: ServerDatabases2
        public ActionResult Index()
        {
            var serverDatabases = db.ServerDatabases.Include(s => s.Employee).Include(s => s.Server);
            return View(serverDatabases.ToList());
        }

        // GET: ServerDatabases2/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServerDatabase serverDatabase = db.ServerDatabases.Find(id);
            if (serverDatabase == null)
            {
                return HttpNotFound();
            }
            return View(serverDatabase);
        }

        // GET: ServerDatabases2/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name");
            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name");
            return View();
        }

        // POST: ServerDatabases2/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Size,EmployeeId,NumberOfUsers,ServerId")] ServerDatabase serverDatabase)
        {
            if (ModelState.IsValid)
            {
                db.ServerDatabases.Add(serverDatabase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", serverDatabase.EmployeeId);
            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name", serverDatabase.ServerId);
            return View(serverDatabase);
        }

        // GET: ServerDatabases2/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServerDatabase serverDatabase = db.ServerDatabases.Find(id);
            if (serverDatabase == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", serverDatabase.EmployeeId);
            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name", serverDatabase.ServerId);
            return View(serverDatabase);
        }

        // POST: ServerDatabases2/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Size,EmployeeId,NumberOfUsers,ServerId")] ServerDatabase serverDatabase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serverDatabase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "Name", serverDatabase.EmployeeId);
            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name", serverDatabase.ServerId);
            return View(serverDatabase);
        }

        // GET: ServerDatabases2/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServerDatabase serverDatabase = db.ServerDatabases.Find(id);
            if (serverDatabase == null)
            {
                return HttpNotFound();
            }
            return View(serverDatabase);
        }

        // POST: ServerDatabases2/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServerDatabase serverDatabase = db.ServerDatabases.Find(id);
            db.ServerDatabases.Remove(serverDatabase);
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
