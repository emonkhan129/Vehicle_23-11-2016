using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using VehicleMVC.Models;

namespace VehicleMVC.Controllers
{
    public class ScheduleVehicleController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: /ScheduleVehicle/
        public ActionResult Index()
        {
            var schedulevehicles = db.ScheduleVehicles.Include(s => s.Shift).Include(s => s.Vehicle);
            return View(schedulevehicles.ToList());
        }

        // GET: /ScheduleVehicle/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleVehicle schedulevehicle = db.ScheduleVehicles.Find(id);
            if (schedulevehicle == null)
            {
                return HttpNotFound();
            }
            return View(schedulevehicle);
        }

        public ActionResult ViewScheduleOfVehicle()
        {
            ViewBag.ShiftId = new SelectList(db.Shifts, "Id", "Shifts");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegNo");
            return View();
        }
       
        public ActionResult ViewScheduleOfVehicles(int? id)
        {
            ////ViewBag.ShiftId = new SelectList(db.Shifts, "Id", "Shifts");
            ////ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegNo");
            ////return View();

           
            //ScheduleVehicle schedulevehicle = db.ScheduleVehicles.Find(id);
            //ViewBag.Data = schedulevehicle;
            ////if (schedulevehicle == null)
            ////{
            ////    return HttpNotFound();
            ////}
            //return View(ViewBag.Data);
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleVehicle schedulevehicle = db.ScheduleVehicles.Find(id);
            if (schedulevehicle == null)
            {
                return HttpNotFound();
            }
            return View(schedulevehicle);
        }
        

        // GET: /ScheduleVehicle/Create
        public ActionResult Create()
        {
            ViewBag.ShiftId = new SelectList(db.Shifts, "Id", "Shifts");
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegNo");
            return View();
        }

        // POST: /ScheduleVehicle/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,VehicleId,Date,ShiftId,BookedBy,Address")] ScheduleVehicle schedulevehicle)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleVehicles.Add(schedulevehicle);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ShiftId = new SelectList(db.Shifts, "Id", "Shifts", schedulevehicle.ShiftId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegNo", schedulevehicle.VehicleId);
            return View(schedulevehicle);
        }

        // GET: /ScheduleVehicle/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleVehicle schedulevehicle = db.ScheduleVehicles.Find(id);
            if (schedulevehicle == null)
            {
                return HttpNotFound();
            }
            ViewBag.ShiftId = new SelectList(db.Shifts, "Id", "Shifts", schedulevehicle.ShiftId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegNo", schedulevehicle.VehicleId);
            return View(schedulevehicle);
        }

        // POST: /ScheduleVehicle/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,VehicleId,Date,ShiftId,BookedBy,Address")] ScheduleVehicle schedulevehicle)
        {
            if (ModelState.IsValid)
            {
                db.Entry(schedulevehicle).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ShiftId = new SelectList(db.Shifts, "Id", "Shifts", schedulevehicle.ShiftId);
            ViewBag.VehicleId = new SelectList(db.Vehicles, "Id", "RegNo", schedulevehicle.VehicleId);
            return View(schedulevehicle);
        }

        // GET: /ScheduleVehicle/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleVehicle schedulevehicle = db.ScheduleVehicles.Find(id);
            if (schedulevehicle == null)
            {
                return HttpNotFound();
            }
            return View(schedulevehicle);
        }

        // POST: /ScheduleVehicle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleVehicle schedulevehicle = db.ScheduleVehicles.Find(id);
            db.ScheduleVehicles.Remove(schedulevehicle);
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
