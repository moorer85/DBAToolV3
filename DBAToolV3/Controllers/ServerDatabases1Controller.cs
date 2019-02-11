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
        private static  int _selectedServer = 1;

        // GET: ServerDatabases1
        [HttpGet]
        public ActionResult Index()
        {
            var servers = db.Servers;
            ViewBag.SelectedServers = new SelectList(servers, "ID", "Name", _selectedServer);
            var serverDatabases = db.ServerDatabases.Include(s => s.Server);
            return View(serverDatabases.ToList());
        }
        [HttpPost]
        public ActionResult Index(FormCollection form)
        {
            ViewBag.YouSelected = form["SelectedServers"];
            int YouSelected = Convert.ToInt32(ViewBag.YouSelected);
            _selectedServer = YouSelected;

            var servers = db.Servers;
            ViewBag.SelectedServers = new SelectList(servers, "ID", "Name", ViewBag.YouSelected);
            var serverDatabases = db.ServerDatabases.Where(d => d.ServerId == YouSelected).Include(s => s.Server);
            return View(serverDatabases.ToList());
        }

        // GET: ServerDatabases1/Details/5
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

        // GET: ServerDatabases1/Create
        public ActionResult Create()
        {
        

            ViewBag.ServerId = new SelectList(db.Servers, "Id", "Name",_selectedServer);
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
                db.ServerDatabases.Add(serverDatabase);
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
            ServerDatabase serverDatabase = db.ServerDatabases.Find(id);
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
            ServerDatabase serverDatabase = db.ServerDatabases.Find(id);
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
