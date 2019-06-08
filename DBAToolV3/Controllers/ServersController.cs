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
    public class ServersController : Controller
    {
       // private DBAToolV3Context db = new DBAToolV3Context();
        private ServerService _server = new ServerService();

        // GET: Servers
        public ActionResult Index()
        {
          
            return View(_server.GetAll());
        }

        // GET: Servers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Server server = _server.Get(id);
            //Server server = db.Servers.Find(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return View(server);
        }

        // GET: Servers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Servers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Memory,CpuCore,CpuSpeed,PurchaseDate,ImageUrl")] Server server)
        {
            if (ModelState.IsValid)
            {
                //  db.Servers.Add(server);
                //  db.SaveChanges();
                _server.Add(server);

                return RedirectToAction("Index");
            }

            return View(server);
        }

        // GET: Servers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Server server = _server.Get(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return View(server);
        }

        // POST: Servers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Memory,CpuCore,CpuSpeed,PurchaseDate,ImageUrl")] Server server)
        {
            if (ModelState.IsValid)
            {
                // db.Entry(server).State = EntityState.Modified;
                //  db.SaveChanges();
                _server.Update(server);


                return RedirectToAction("Index");
            }
            return View(server);
        }

        // GET: Servers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Server server = _server.Get(id);
            if (server == null)
            {
                return HttpNotFound();
            }
            return View(server);
        }

        // POST: Servers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Server server = _server.Get(id);
            _server.Delete(server);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _server.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
