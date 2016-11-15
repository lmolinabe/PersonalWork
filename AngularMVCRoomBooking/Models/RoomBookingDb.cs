using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularMVCRoomBooking.Models
{
    public class RoomBookingDb : DbContext
    {
        public RoomBookingDb() : base("name=RoomBookingDBConnection")
        {

        }

        public DbSet<RoomBooking> RoomBookings { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<BookingStatus> BookingStatuses { get; set; }
        public DbSet<PaymentStatus> PaymentStatuses { get; set; }
    }
}