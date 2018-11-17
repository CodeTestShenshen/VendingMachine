using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace VendingMachineApp.Models
{
    public enum States { NSW, WA, VIC, QLD}
    public class Machine : BaseModel, IActive
    {
        [Required]
        public string SeriesNumber { get; set; } 
        [StringLength (200)]
        [Required]
        public string Location { get; set; }
        [StringLength(4)]
        [Required]
        public string PostCode { get; set; }
        [Required]
        public States State { get; set; }
        [Required]
        public bool IsActive { get; set; }

    }
}