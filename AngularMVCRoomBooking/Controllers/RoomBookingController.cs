using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AngularMVCRoomBooking.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace AngularMVCRoomBooking.Controllers
{
    public class RoomBookingController : Controller
    {
        private RoomBookingDb db = new RoomBookingDb();

        public ActionResult GetRoomBookings()
        {
            var list = db.RoomBookings.ToList();

            return GetJsonContentResult(list);
            //return new HttpStatusCodeResult(404,"Custo Error Message");
        }

        // GET: RoomBooking/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomBooking roomBooking = db.RoomBookings.Find(id);
            if (roomBooking == null)
            {
                return HttpNotFound();
            }
            return View(roomBooking);
        }

        // GET: RoomBooking/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        // POST: RoomBooking/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "Id,StartDate,EndDate,AdvancePaid,TotalPaid")] RoomBooking roomBooking)
        public ActionResult Create(RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                var id = new { id = 12345 };
                return GetJsonContentResult(id);
                //return new HttpStatusCodeResult(HttpStatusCode.Created, "New RoomBooking added");
            }

            List<string> errors = new List<string>();
            errors.Add("Insert Failed.");
            if (!ModelState.IsValidField("TotalPaid"))
            {
                errors.Add("Total Paid musta have a numeric value");
            }

            var s = string.Join("\n",errors);

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, string.Join(" ",errors));

            if (ModelState.IsValid)
            {
                db.RoomBookings.Add(roomBooking);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(roomBooking);
        }

        public ContentResult GetJsonContentResult(object data)
        {
            var camelCaseFormatter = new JsonSerializerSettings();
            camelCaseFormatter.ContractResolver = new CamelCasePropertyNamesContractResolver();
            var jsonResult = new ContentResult
            {
                Content = JsonConvert.SerializeObject(data, camelCaseFormatter),
                ContentType = "application/json"
            };

            return jsonResult;
        }

        public ActionResult Update(RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.OK, "Update success");
            }

            List<string> errors = new List<string>();
            errors.Add("Update Failed.");
            if (!ModelState.IsValidField("TotalPaid"))
            {
                errors.Add("Total Paid musta have a numeric value");
            }

            var s = string.Join("\n", errors);

            return new HttpStatusCodeResult(HttpStatusCode.InternalServerError, string.Join(" ", errors));
        }

        // GET: RoomBooking/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomBooking roomBooking = db.RoomBookings.Find(id);
            if (roomBooking == null)
            {
                return HttpNotFound();
            }
            return View(roomBooking);
        }

        // POST: RoomBooking/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,StartDate,EndDate,AdvancePaid,TotalPaid")] RoomBooking roomBooking)
        {
            if (ModelState.IsValid)
            {
                db.Entry(roomBooking).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(roomBooking);
        }

        // GET: RoomBooking/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RoomBooking roomBooking = db.RoomBookings.Find(id);
            if (roomBooking == null)
            {
                return HttpNotFound();
            }
            return View(roomBooking);
        }

        // POST: RoomBooking/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RoomBooking roomBooking = db.RoomBookings.Find(id);
            db.RoomBookings.Remove(roomBooking);
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
