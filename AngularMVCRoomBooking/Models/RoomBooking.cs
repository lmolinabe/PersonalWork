using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AngularMVCRoomBooking.Models
{
    public class RoomBooking
    {
        public int Id { get; set; }
        public virtual Room Room { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public virtual BookingStatus BookingStatus { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public float AdvancePaid { get; set; }
        [Required]
        [Range(1,5000)]
        public float TotalPaid { get; set; }
    }
}