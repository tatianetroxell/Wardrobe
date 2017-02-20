using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Wardrobe.Models;

namespace Wardrobe.Controllers
{
    public class ClosetsController : Controller
    {
        private WardrobeEntities db = new WardrobeEntities();

        // GET: Closets
        public ActionResult Index()
        {
            var closets = db.Closets.Include(c => c.Accessory).Include(c => c.Bottom).Include(c => c.Sho).Include(c => c.Top);
            return View(closets.ToList());
        }

        // GET: Closets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closet closet = db.Closets.Find(id);
            if (closet == null)
            {
                return HttpNotFound();
            }
            return View(closet);
        }

        // GET: Closets/Create
        public ActionResult Create()
        {
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name");
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name");
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name");
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name");
            return View();
        }

        // POST: Closets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClosetID,TopID,BottomID,ShoeID,AccessoryID")] Closet closet)
        {
            if (ModelState.IsValid)
            {
                db.Closets.Add(closet);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", closet.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", closet.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", closet.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", closet.TopID);
            return View(closet);
        }

        // GET: Closets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closet closet = db.Closets.Find(id);
            if (closet == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", closet.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", closet.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", closet.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", closet.TopID);
            return View(closet);
        }

        // POST: Closets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClosetID,TopID,BottomID,ShoeID,AccessoryID")] Closet closet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(closet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccessoryID = new SelectList(db.Accessories, "AccessoryID", "Name", closet.AccessoryID);
            ViewBag.BottomID = new SelectList(db.Bottoms, "BottomID", "Name", closet.BottomID);
            ViewBag.ShoeID = new SelectList(db.Shoes, "ShoeID", "Name", closet.ShoeID);
            ViewBag.TopID = new SelectList(db.Tops, "TopID", "Name", closet.TopID);
            return View(closet);
        }

        // GET: Closets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Closet closet = db.Closets.Find(id);
            if (closet == null)
            {
                return HttpNotFound();
            }
            return View(closet);
        }

        // POST: Closets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Closet closet = db.Closets.Find(id);
            db.Closets.Remove(closet);
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
