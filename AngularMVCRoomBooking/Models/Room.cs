using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMVCRoomBooking.Models
{
    public class Room
    {
        public Room()
        {
            RoomBookings = new List<RoomBooking>();
        }

        public int Id { get; set; }
        public int Number { get; set; }
        public RoomType RoomType { get; set; }
        public double Price { get; set; }

        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}