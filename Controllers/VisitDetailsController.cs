using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using lz523915_MIS4200.Models;

namespace lz523915_MIS4200.Controllers
{
    public class VisitDetailsController : Controller
    {
        private lz523915_MIS4200Context db = new lz523915_MIS4200Context();

        // GET: VisitDetails
        public ActionResult Index()
        {
            var visitDetails = db.VisitDetails.Include(v => v.Pet).Include(v => v.Treatment);
            return View(visitDetails.ToList());
        }

        // GET: VisitDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitDetail visitDetail = db.VisitDetails.Find(id);
            if (visitDetail == null)
            {
                return HttpNotFound();
            }
            return View(visitDetail);
        }

        // GET: VisitDetails/Create
        public ActionResult Create()
        {
            ViewBag.petId = new SelectList(db.Pets, "petId", "petBreed");
            ViewBag.treatmentId = new SelectList(db.Treatments, "treatmentId", "treatmentDescription");
            return View();
        }

        // POST: VisitDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "visitDetailId,visitPrice,petId,treatmentId")] VisitDetail visitDetail)
        {
            if (ModelState.IsValid)
            {
                db.VisitDetails.Add(visitDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.petId = new SelectList(db.Pets, "petId", "petBreed", visitDetail.petId);
            ViewBag.treatmentId = new SelectList(db.Treatments, "treatmentId", "treatmentDescription", visitDetail.treatmentId);
            return View(visitDetail);
        }

        // GET: VisitDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitDetail visitDetail = db.VisitDetails.Find(id);
            if (visitDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.petId = new SelectList(db.Pets, "petId", "petBreed", visitDetail.petId);
            ViewBag.treatmentId = new SelectList(db.Treatments, "treatmentId", "treatmentDescription", visitDetail.treatmentId);
            return View(visitDetail);
        }

        // POST: VisitDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "visitDetailId,visitPrice,petId,treatmentId")] VisitDetail visitDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(visitDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.petId = new SelectList(db.Pets, "petId", "petBreed", visitDetail.petId);
            ViewBag.treatmentId = new SelectList(db.Treatments, "treatmentId", "treatmentDescription", visitDetail.treatmentId);
            return View(visitDetail);
        }

        // GET: VisitDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VisitDetail visitDetail = db.VisitDetails.Find(id);
            if (visitDetail == null)
            {
                return HttpNotFound();
            }
            return View(visitDetail);
        }

        // POST: VisitDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VisitDetail visitDetail = db.VisitDetails.Find(id);
            db.VisitDetails.Remove(visitDetail);
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
