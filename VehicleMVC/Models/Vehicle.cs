using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VehicleMVC.Models
{
    public class Vehicle
    {

        public int Id { get; set; }
        [Required(ErrorMessage = "RegNo is Required")]
        [DisplayName("Reg. No.")]
        
        [Remote("RegNo","Vehicle",ErrorMessage = "This Registration No Already Exists.")]
         public String RegNo { get; set; }
        [Required(ErrorMessage = "EngineNo is Required")]
        [DisplayName("Engine. No.")]
        [Remote("EngineNo2", "Vehicle", ErrorMessage = "This Engine No Already Exists.")]
       
        public string EngineNo { get; set; }

        public virtual List<ScheduleVehicle>  ScheduleVehicles { get; set; }
    }
}