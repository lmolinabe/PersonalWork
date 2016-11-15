namespace AngularMVCRoomlBooking.Migrations
{
    using AngularMVCRoomBooking.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularMVCRoomBooking.Models.RoomBookingDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AngularMVCRoomBooking.Models.RoomBookingDb context)
        {
            context.Rooms.AddOrUpdate(r => r.Number,
                new Room { Id = 1, Number = 1, RoomType = new RoomType { Id = 1, Name = "Single" }, Price = 0.00 },
                new Room { Id = 2, Number = 2, RoomType = new RoomType { Id = 2, Name = "Double" }, Price = 0.00 },
                new Room { Id = 3, Number = 3, RoomType = new RoomType { Id = 3, Name = "Twin" }, Price = 0.00 },
                new Room { Id = 4, Number = 4, RoomType = new RoomType { Id = 4, Name = "Suite" }, Price = 0.00 }
            );

            context.BookingStatuses.AddOrUpdate(bs => bs.Name,
                new BookingStatus { Id = 1, Name = "Free" },
                new BookingStatus { Id = 2, Name = "Reserved" },
                new BookingStatus { Id = 3, Name = "Occupied" }
            );

            context.PaymentStatuses.AddOrUpdate(bs => bs.Name,
                new PaymentStatus { Id = 1, Name = "Paid" },
                new PaymentStatus { Id = 2, Name = "Advance" }
            );
        }
    }
}
