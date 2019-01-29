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
using DBAToolV3.Models.Service;

namespace DBAToolV3.Controllers
{
    public class ServerDatabasesController : Controller
    {
        private DBAToolV3Context db = new DBAToolV3Context();
        private ServerDatabaseService _db = new ServerDatabaseService();

        // GET: ServerDatabases
        public ActionResult Index(int? selectedServer)
        {
            var servers = _db.GetAll();
           // var servers = db.Servers.OrderBy(q => q.Name).ToList();
            ViewBag.SelectedServers = new SelectList(servers, "ID", "Name", selectedServer);



            return View(db.Databases.ToList());
        }

        // GET: ServerDatabases/Details/5
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

        // GET: ServerDatabases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ServerDatabases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Size,NumberOfUsers")] ServerDatabase serverDatabase)
        {
            if (ModelState.IsValid)
            {
                db.Databases.Add(serverDatabase);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(serverDatabase);
        }

        // GET: ServerDatabases/Edit/5
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
            return View(serverDatabase);
        }

        // POST: ServerDatabases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Size,NumberOfUsers")] ServerDatabase serverDatabase)
        {
            if (ModelState.IsValid)
            {
                db.Entry(serverDatabase).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(serverDatabase);
        }

        // GET: ServerDatabases/Delete/5
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

        // POST: ServerDatabases/Delete/5
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
