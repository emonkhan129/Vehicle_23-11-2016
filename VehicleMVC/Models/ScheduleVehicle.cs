using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VehicleMVC.Models
{
    public class ScheduleVehicle
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Vehicle Reg No is Required")]
        [DisplayName("Vehicle Reg No")]
       
        public int VehicleId { get; set; }
        [Required(ErrorMessage = "Date is Required")]
        [DisplayName("Date")]
       
        public DateTime Date { get; set; }
        [Required(ErrorMessage = "Shift is Required")]
        [DisplayName("Shift")]
       
        public int ShiftId { get; set; }
        [Required(ErrorMessage = "Booked By is Required")]
        [DisplayName("Booked By")]
       
        public string BookedBy { get; set; }
        [Required(ErrorMessage = "Address is Required")]
        [DisplayName("Address")]
       
        public String Address { get; set; }

        public virtual Vehicle Vehicle { get; set; }
        public virtual Shift Shift { get; set; }

    }
}