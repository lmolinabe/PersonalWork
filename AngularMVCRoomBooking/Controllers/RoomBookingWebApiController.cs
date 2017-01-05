using AngularMVCRoomBooking.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularMVCHotelBooking.Controllers
{
    public class RoomBookingWebApiController : ApiController
    {
        private RoomBookingDb db = new RoomBookingDb();

        // GET: api/RoomBookingWebApi
        public HttpResponseMessage Get()
        {
            var response = Request.CreateResponse(HttpStatusCode.OK, db.RoomBookings.ToList());
            return response;
        }

        // GET: api/RoomBookingWebApi/5
        public HttpResponseMessage Get(int? id)
        {
            if (id == null)
            {
                return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            RoomBooking roomBooking = db.RoomBookings.Find(id);
            if (roomBooking == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            var response = Request.CreateResponse(HttpStatusCode.OK, roomBooking);
            return response;
        }

        // POST: api/RoomBookingWebApi
        public HttpResponseMessage Post([FromBody]RoomBooking roomBooking)
        {
            HttpResponseMessage response = null;

            try
            {
                if (ModelState.IsValid)
                {
                    db.RoomBookings.Add(roomBooking);
                    db.SaveChanges();

                    response = new HttpResponseMessage(HttpStatusCode.OK);
                    response.Content = new StringContent("12345");
                    return response;
                }

                List<string> errors = new List<string>();
                errors.Add("Insert Failed.");
                if (!ModelState.IsValidField("TotalPaid"))
                {
                    errors.Add("Total Paid must has a numeric value");
                }

                var s = string.Join("\n", errors);


                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(string.Join(" ", errors));

                return response;
            }
            catch (Exception e)
            {
                response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
                response.Content = new StringContent(e.Message);

                return response;
            }
        }

        // PUT: api/RoomBookingWebApi/5
        public HttpResponseMessage Put([FromBody]RoomBooking roomBooking)
        {
            HttpResponseMessage response = null;

            if (ModelState.IsValid)
            {
                db.Entry(roomBooking).State = EntityState.Modified;
                db.SaveChanges();

                response = new HttpResponseMessage(HttpStatusCode.OK);
                return response;
            }

            List<string> errors = new List<string>();
            errors.Add("Update Failed.");
            if (!ModelState.IsValidField("TotalPaid"))
            {
                errors.Add("Total Paid musta have a numeric value");
            }

            var s = string.Join("\n", errors);

            response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            response.Content = new StringContent(string.Join(" ", errors));

            return response;
        }

        // DELETE: api/RoomBookingWebApi/5
        public void Delete(int id)
        {

        }
    }
}
