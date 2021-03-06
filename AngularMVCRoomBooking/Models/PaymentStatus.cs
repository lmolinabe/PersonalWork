﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularMVCRoomBooking.Models
{
    public class PaymentStatus
    {
        public PaymentStatus()
        {
            RoomBookings = new List<RoomBooking>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<RoomBooking> RoomBookings { get; set; }
    }
}