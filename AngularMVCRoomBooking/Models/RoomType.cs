using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMVCRoomBooking.Models
{
    public class RoomType
    {
        public RoomType()
        {
            Rooms = new List<Room>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Room> Rooms { get; set; }
    }
}