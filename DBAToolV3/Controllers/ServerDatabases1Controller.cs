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
    public class ServerDatabases1Controller : Controller
    {
        private DBAToolV3Context db = new DBAToolV3Context();

        // GET: ServerDatabases1
        public ActionResult Index()
        {
            var databases = db.Databases.Include(s => s.Server);
            return View(databases.ToList());
        }

        // GET: ServerDatabases1/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServerDatabase serverDatabase = db.Databases.Find(id);
            if (serverDatabase == null)
            {
                return HttpNotFound();
            }
            return View(serverDatabase);
        }

        // GET: ServerDatabases1/Create
        public ActionResult Create()
        {
            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name");
            return View();
        }

        // POST: ServerDatabases1/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Size,NumberOfUsers,ServerId")] ServerDatabase serverDatabase)
        {
            if (ModelState.IsValid)
            {
                db.Databases.Add(serverDatabase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name", serverDatabase.ServerId);
            return View(serverDatabase);
        }

        // GET: ServerDatabases1/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServerDatabase serverDatabase = db.Databases.Find(id);
            if (serverDatabase == null)
            {
                return HttpNotFound();
            }
            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name", serverDatabase.ServerId);
            return View(serverDatabase);
        }

        // POST: ServerDatabases1/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Size,NumberOfUsers,ServerId")] ServerDatabase serverDatabase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serverDatabase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name", serverDatabase.ServerId);
            return View(serverDatabase);
        }

        // GET: ServerDatabases1/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ServerDatabase serverDatabase = db.Databases.Find(id);
            if (serverDatabase == null)
            {
                return HttpNotFound();
            }
            return View(serverDatabase);
        }

        // POST: ServerDatabases1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ServerDatabase serverDatabase = db.Databases.Find(id);
            db.Databases.Remove(serverDatabase);
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
